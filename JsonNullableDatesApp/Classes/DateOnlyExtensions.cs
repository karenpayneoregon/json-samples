namespace JsonNullableDatesApp.Classes
{
    public static class DateOnlyExtensions
    {
        /// <summary>
        /// Converts a nullable <see cref="DateOnly"/> value to a string representation.
        /// </summary>
        /// <param name="date">The nullable <see cref="DateOnly"/> value to be converted.</param>
        /// <returns>
        /// Returns "None" if the <paramref name="date"/> is <c>null</c>;
        /// otherwise, returns the string representation of the <paramref name="date"/>.
        /// </returns>
        public static string Conditional(this DateOnly? date) 
            => date is null ? "Unknown" : date.Value.ToString("D");
    }
}
