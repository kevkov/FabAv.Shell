using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace FabAv.Shell.Theme;

public static class ColorTheme
{
    public static void LoadDarkTheme(global::Avalonia.Application app)
    {
        app.Styles.Add(new Dark());
    }   
    
    public static void LoadLightTheme(global::Avalonia.Application app)
    {
        app.Styles.Add(new Light());
    }  
}

public class Dark : Styles
{
    public Dark() => AvaloniaXamlLoader.Load(this);
}

public class Light : Styles
{
    public Light() => AvaloniaXamlLoader.Load(this);
}