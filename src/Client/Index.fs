module Index

open Elmish
open Fable.Remoting.Client
open Shared

type Model = { Images: string list; Input: string }

type Msg =
    | GotImages of string list

let todosApi =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<ITodosApi>



let bgImages =
    [ "https://www.muchbetteradventures.com/magazine/content/images/size/w2000/2019/10/29122602/iStock-971053374.jpg"
      "https://thelandscapephotoguy.com/wp-content/uploads/2019/01/landscape%20new%20zealand%20S-shape.jpg"
      "https://photographylife.com/wp-content/uploads/2017/01/What-is-landscape-photography.jpg"
      "https://i2.wp.com/digital-photography-school.com/wp-content/uploads/2019/02/Landscapes-01-jeremy-flint.jpg?resize=1500%2C1000&ssl=1" ]


let init () : Model * Cmd<Msg> =
    let model = { Images = []; Input = "" }

    let cmd =
        Cmd.OfAsync.perform
            (fun () -> async {
                do! Async.Sleep 2000
                return bgImages })
            ()
            GotImages

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | GotImages images -> { model with Images = images}, Cmd.none

open Feliz
open Feliz.Bulma
open Feliz.ReactAwesomeSlider


let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        //AwesomeSlider.create [
        //    AwesomeSlider.animation FoldOutAnimation
        //    AwesomeSlider.fillParent false
        //    AwesomeSlider.organicArrows true
        //    AwesomeSlider.bullets true
        //    AwesomeSlider.infinite true
        //    AwesomeSlider.mobileTouch false
        //    AwesomeSlider.startup true
        //    AwesomeSlider.buttonContentRight (Html.div "Right")
        //    AwesomeSlider.customContent (Html.div "Hello")
        //    AwesomeSlider.startupScreen (Html.div "Loading")
        //    AwesomeSlider.children [
        //        for bgImage in model.Images do
        //        Html.div [
        //            prop.style [
        //                style.backgroundImageUrl bgImage
        //                style.backgroundSize.cover
        //            ]
        //        ]
        //    ]
        //]
        AutoplaySlider.create [
            AutoplaySlider.play true
            AutoplaySlider.animation FoldOutAnimation
            AutoplaySlider.interval 3000
            AutoplaySlider.cancelOnInteraction false
            AwesomeSlider.children [
                for bgImage in (List.rev model.Images) do
                Html.div [
                    prop.style [
                        style.backgroundImageUrl bgImage
                        style.backgroundSize.cover
                    ]
                ]
            ]
        ]
    ]
