using System.Reflection;

namespace Data
{
    internal static class Extension
    {
        public static object? GetPropertyVAlue(this object source, PropertyInfo pi)
        {
            object? value = pi.GetValue(source);

#pragma warning disable CS8605 // Unboxing a possibly null value.
            return pi.PropertyType.FullName switch
            {
                "System.Byte" => Convert.ToInt32(value),
                "System.DateOnly" => new Google.Type.Date { Year = ((DateOnly)value).Year, Month = ((DateOnly)value).Month, Day = ((DateOnly)value).Day },
                "System.Guid" => value?.ToString(),
                _ => value,
            };
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }
    }
}
