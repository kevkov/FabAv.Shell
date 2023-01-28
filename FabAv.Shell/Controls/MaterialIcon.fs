namespace FabAv.Shell.Controls

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia
open Fabulous
open Fabulous.Avalonia
open Material.Icons.Avalonia

type IFabMaterialIcon =
    inherit IFabTemplatedControl

module MaterialIcon =
    let WidgetKey = Widgets.register<MaterialIcon> ()

    let Kind = Attributes.defineAvaloniaPropertyWithEquality MaterialIcon.KindProperty

    let Width = Attributes.defineAvaloniaPropertyWithEquality MaterialIcon.WidthProperty

    let Height =
        Attributes.defineAvaloniaPropertyWithEquality MaterialIcon.HeightProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWidget MaterialIcon.ForegroundProperty


[<AutoOpen>]
module MaterialIconBuilders =
    type View with

        static member inline MaterialIcon(kind) =
            WidgetBuilder<'msg, IFabMaterialIcon>(
                MaterialIcon.WidgetKey,
                MaterialIcon.Kind.WithValue(kind)
            )
            
    [<Extension>]
    type MaterialIconModifiers =
        [<Extension>]
        static member inline foregroundStyle<'msg, 'T when 'T :> IFabMaterialIcon>(this: WidgetBuilder<'msg, 'T>, resourceName: string) =
            let found, styleValue = Application.Current.Styles.TryGetResource resourceName
            if found then
                this.foreground(View.SolidColorBrush(Color.Parse(styleValue.ToString())))
            else this