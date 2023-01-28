namespace FabAv.Shell.Controls

open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia
open type View
open Extensions
open Material.Icons

[<AutoOpen>]
module MobileMenuPage =
    
    type MenuItem = {
        Header: string
        Kind: MaterialIconKind
        Content: obj
    }

    let MobileMenuPage<'msg> (index:int) (msg: 'msg) =
        let menuItems = [
            { Header = "DashBoard"; Kind = MaterialIconKind.CircleOutline; Content = null }
            { Header = "Settings"; Kind = MaterialIconKind.Settings; Content = null }
        ]
        let icon = MaterialIcon(enum<Material.Icons.MaterialIconKind> index)
                        .height(35.)
                        .width(35.)
                        .foregroundStyle("SukiText")
        let pane () =
            Grid() {
               (Canvas() {
                    Border(
                        (VStack() {
                            Button(msg, Grid () { icon })
                                .classes("Accent")
                                .horizontalAlignment(HorizontalAlignment.Right)
                                .margin(Thickness(0,5,25,0))
                            
                            Grid() {
                                TextBlock("Header").foreground(SolidColorBrush(Colors.Green))
                            }
                            
                            (Grid() {
                                TextBlock("")
                            }).height(40.)
                            
                            for mi in menuItems do
                                RadioButton(
                                    Grid() {
                                        Dock() {
                                            MaterialIcon(mi.Kind)
                                                .height(22.)
                                                .margin(Thickness(15,0,0,0))
                                                .width(22.)
                                            TextBlock(mi.Header)
                                                .classes("h4")
                                                .fontWeight(FontWeight.Medium)
                                                .margin(Thickness(20,8,8,8))
                                        }
                                    }, true
                                )
                                    .classes("MenuItemMobile")
                                    .groupName("MenuItemsGroup")
                                    .height(50.)
                                    .horizontalAlignment(HorizontalAlignment.Center)
                                    .isEnabled(true)
                                    .width(356)
                        })
                            .margin(Thickness(-20,0,0,0.))
                    )
                        .borderThickness(0., 0., 1., 0.)
                        .borderBrushStyle("SukiBorderBrush")
                })
                    .backgroundStyle("SukiBackground")
            }
            
        let content () =
            TextBlock("World")

        View.SplitView(pane(), content())
            .compactPaneLength(0)
            .displayMode(Avalonia.Controls.SplitViewDisplayMode.CompactOverlay)
            .isPaneOpen(true)
            .openPaneLength(316.)
            .useLightDismissOverlayMode(true)

