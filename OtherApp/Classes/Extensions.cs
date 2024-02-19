using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace OtherApp.Classes;
public static class Extensions
{
    // Dictionary to hold type initialization methods' cache 
    private static Dictionary<Type, Action<object>> _typesInitializers = new();

    /// <summary>
    /// Implements precompiled setters with embedded constant values from DefaultValueAttributes
    /// </summary>
    public static void ApplyDefaultValues(this object _this)
    {
        // Attempt to get it from cache
        if (!_typesInitializers.TryGetValue(_this.GetType(), out var setter))
        {
            // If no initializers are added do nothing
            setter = (o) => { };

            // Iterate through each property
            ParameterExpression objectTypeParam = Expression.Parameter(typeof(object), "this");
            foreach (PropertyInfo prop in _this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Expression dva;

                // Skip read only properties
                if (!prop.CanWrite)
                {
                    continue;
                }

                // There are no more than one attribute of this type
                DefaultValueAttribute[] attr = prop.GetCustomAttributes(typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];

                // Skip properties with no DefaultValueAttribute
                if (attr?[0] == null)
                {
                    continue;
                }

                // Build the Lambda expression
#if DEBUG
                // Make sure types do match
                try
                {
                    dva = Expression.Convert(Expression.Constant(attr[0].Value), prop.PropertyType);
                }
                catch (InvalidOperationException e)
                {
                    string error =
                        $"Type of DefaultValueAttribute({((attr[0].Value is string) ? "\"" : "")}" +
                        $"{attr[0].Value.ToString()}{((attr[0].Value is string) ? "\"" : "")}) does not match type of property " +
                        $"{_this.GetType().Name}.{prop.Name}";

                    throw (new InvalidOperationException(error, e));
                }
#else
                    dva = Expression.Convert(Expression.Constant(attr[0].Value), prop.PropertyType);
#endif
                Expression setExpression = Expression.Call(Expression.TypeAs(objectTypeParam, _this.GetType()), prop.GetSetMethod()!, dva);
                Expression<Action<object>> setLambda = Expression.Lambda<Action<object>>(setExpression, objectTypeParam);

                // Add this action to multicast delegate
                setter += setLambda.Compile();
            }

            // Save in the type cache
            _typesInitializers.Add(_this.GetType(), setter);
        }

        // Initialize member properties
        setter(_this);
    }

    /// <summary>
    /// Implements cache of ResetValue delegates
    /// </summary>
    public static void ResetDefaultValues(this object _this)
    {
        // Attempt to get it from cache
        if (!_typesInitializers.TryGetValue(_this.GetType(), out var setter))
        {
            // Init delegate with empty body,
            // If no initializers are added do nothing
            setter = (o) => { };

            // Go through each property and compile Reset delegates
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(_this))
            {
                // Add only these which values can be reset
                if (prop.CanResetValue(_this))
                {
                    setter += prop.ResetValue;
                }
            }

            // Save in the type cache
            _typesInitializers.Add(_this.GetType(), setter);
        }

        // Initialize member properties
        setter(_this);
    }
}
