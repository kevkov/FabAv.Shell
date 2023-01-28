namespace ShellApp

open Fabulous
open Fabulous.Avalonia
open FabAv.Shell.Controls

open type Fabulous.Avalonia.View

module App =
    type Model =
        {MenuModel: MobileMenuPage.Model}

    type Msg =
        | MenuMsg of MobileMenuPage.Msg


    let init () =
        let m, cmd = MobileMenuPage.init ()
        { MenuModel = m }, Cmd.map MenuMsg cmd

    let update msg model =
        match msg with
        | MenuMsg m ->
            let m2, cmd = MobileMenuPage.update model.MenuModel m
            {model with MenuModel = m2}, Cmd.map MenuMsg cmd

    let view model =
        View.map MenuMsg (MobileMenuPage.view model.MenuModel)

    let app model = SingleViewApplication(view model)

    let program = Program.statefulWithCmd init update app
