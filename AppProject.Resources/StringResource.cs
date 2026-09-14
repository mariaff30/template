using System.Globalization;

namespace AppProject.Resources;

public class StringResource
{
    public static string GetString(string key, params object?[] args)
    {
        var message = Resource.ResourceManager.GetString(key, CultureInfo.CurrentCulture) ?? string.Empty;
        return string.Format(message, args);
    }
}
