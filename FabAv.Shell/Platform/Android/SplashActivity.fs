namespace ShellApp.Android

open System
open Android.App
open Android.Content
open Avalonia
open Avalonia.Android
open Avalonia.Markup.Xaml.Styling
open ShellApp
open Fabulous.Avalonia

[<Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)>]
type SplashActivity() =
    inherit AvaloniaSplashActivity()

    override this.CreateAppBuilder() =
        AppBuilder
            .Configure(
                fun () ->
                    let x = Program.startApplication App.program
                    x.Styles.Clear()
                    x.Styles.Add(StyleInclude(Uri("avares://Material.Icons.Avalonia/"), Source = Uri("avares://Material.Icons.Avalonia/App.xaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://FabAv.Shell.Theme/"), Source = Uri("avares://FabAv.Shell.Theme/Light.axaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://FabAv.Shell/Styles/"), Source = Uri("avares://FabAv.Shell/Styles/ButtonStyles.xaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://FabAv.Shell/Styles/"), Source = Uri("avares://FabAv.Shell/Styles/RadioButtonStyles.xaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://FabAv.Shell/Styles/"), Source = Uri("avares://FabAv.Shell/Styles/TextBlockStyles.xaml")))
                    x)
            .UseAndroid()

    override this.OnResume() =
        base.OnResume()
        this.StartActivity(new Intent(Application.Context, typeof<MainActivity>))
