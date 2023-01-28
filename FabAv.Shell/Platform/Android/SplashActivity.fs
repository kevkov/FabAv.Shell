namespace CounterApp.Android

open System
open Android.App
open Android.Content
open Avalonia
open Avalonia.Android
open Avalonia.Markup.Xaml.Styling
open CounterApp
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
                    x.Styles.Add(StyleInclude(Uri("avares://Fabulous.Avalonia.SukiUI.Theme/"), Source = Uri("avares://Fabulous.Avalonia.SukiUI.Theme/Light.axaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://Fabulous.SukiUI/Theme/"), Source = Uri("avares://Fabulous.SukiUI/Theme/ButtonStyles.xaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://Fabulous.SukiUI/Theme/"), Source = Uri("avares://Fabulous.SukiUI/Theme/RadioButtonStyles.xaml")))
                    x.Styles.Add(StyleInclude(Uri("avares://Fabulous.SukiUI/Theme/"), Source = Uri("avares://Fabulous.SukiUI/Theme/TextBlockStyles.xaml")))
                    x)
            .UseAndroid()

    override this.OnResume() =
        base.OnResume()
        this.StartActivity(new Intent(Application.Context, typeof<MainActivity>))
