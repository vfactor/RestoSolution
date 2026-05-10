using System.Reflection;

namespace Data
{
    internal static class Extension
    {
        public static object? GetMapValue(this PropertyInfo pi, object source)
        {
            var value = pi.GetValue(source);

            return pi.PropertyType.FullName switch
            {
                _ => value,
            };
        }
    }
}
