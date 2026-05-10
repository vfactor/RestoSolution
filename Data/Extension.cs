using System.Reflection;

namespace Data
{
    internal static class Extension
    {
        public static object? GetPropertyVAlue(this object source, PropertyInfo pi)
        {
            object? value = pi.GetValue(source);
           
            return pi.PropertyType.FullName switch
            {
                "System.Byte" => Convert.ToInt32(value),
                "System.DateOnly" => new Google.Type.Date { Year = ((DateOnly)value).Year, Month = ((DateOnly)value).Month, Day = ((DateOnly)value).Day },
                "System.Guid" => value?.ToString(),
                _ => value,
            };
        }
    }
}
