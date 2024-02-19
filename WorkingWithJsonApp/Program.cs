using System.ComponentModel;
using System.Text.Json.Serialization;
using WorkingWithJsonApp.Classes;

namespace WorkingWithJsonApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();


        SetupLogging.Development();

        /*
         * This set globally change case-sensitive to case-insensitive but does not work
         * Seems that this is handled natively.
         */
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });


        //builder.Services.AddControllers().AddJsonOptions(options =>
        //{
        //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        //});

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
