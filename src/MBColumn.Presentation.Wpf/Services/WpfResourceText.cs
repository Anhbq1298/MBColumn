using System.Globalization;
namespace MBColumn.Presentation.Wpf.Services;

public static class WpfResourceText
{
    public static string Get(string key)
        => System.Windows.Application.Current?.TryFindResource(key) as string ?? key;

    public static string Format(string key, params object[] args)
        => string.Format(CultureInfo.CurrentCulture, Get(key), args);
}
