namespace FabAv.Shell.Controls

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous.Avalonia
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

module StyledElement =
    
    let Classes = Attributes.defineSimpleScalarWithEquality<string> "StyledElement_Classes" (fun _ newValueOpt node ->
        let target = node.Target :?> StyledElement
        match newValueOpt with
        | ValueNone -> target.Classes.Clear()
        | ValueSome v -> target.Classes <- Classes(v)
    )

[<AutoOpen>]

module Builders =
   type Fabulous.Avalonia.View with    
        static member inline RadioButton(content: WidgetBuilder<'msg, #IFabControl>, isChecked: bool) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one (RadioButton.IsChecked.WithValue(isChecked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
    
module Extensions =
 
    [<Extension>]
    type Modifiers =
        [<Extension>]
        static member inline borderBrushStyle<'msg, 'T when 'T :> IFabBorder>(this: WidgetBuilder<'msg, 'T>, resourceName: string) =
            let found, styleValue = Application.Current.Styles.TryGetResource resourceName
            if found then
                this.borderBrush(View.SolidColorBrush(Color.Parse(styleValue.ToString())))
            else this
            
        [<Extension>]
        static member inline backgroundStyle<'msg, 'T when 'T :> IFabPanel>(this: WidgetBuilder<'msg, 'T>, resourceName: string) =
            let found, styleValue = Application.Current.Styles.TryGetResource resourceName
            if found then
                this.background(View.SolidColorBrush(Color.Parse(styleValue.ToString())))
            else this
            
        [<Extension>]
        static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, clazz: string) =
            this.AddScalar(StyledElement.Classes.WithValue(clazz))
            

