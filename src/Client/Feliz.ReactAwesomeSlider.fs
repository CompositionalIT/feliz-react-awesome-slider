module ReactAwesomeSlider

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

let reactAwesomeSlider: obj = importDefault "react-awesome-slider"

importAll "react-awesome-slider/dist/custom-animations/cube-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fall-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fold-out-animation.css"
importAll "react-awesome-slider/dist/custom-animations/open-animation.css"
importAll "react-awesome-slider/dist/custom-animations/scale-out-animation.css"
importAll "react-awesome-slider/dist/styles.css"
//let splitChildProps props =
//    let (children, props) =
//        props
//        |> unbox<(string*obj) seq>
//        |> Seq.toArray
//        |> Array.partition (fun (key,_) -> key = "children")
//
//    let children = children |> Array.tryLast |> Option.map snd |> Option.toObj
//
//    {| Props = props; Children = children |}

[<Erase>]
type IAwesomeSliderProperty = interface end
//    abstract animation: string
//    abstract styles: obj
//    abstract children: obj

module Interop =
    let inline mkSliderAttr (key: string) (value: obj) : IAwesomeSliderProperty = unbox (key, value)


type AwesomeSlider =
    static member inline animation (s: string) = unbox<IAwesomeSliderProperty>("animation" ==> s)
    static member inline selected (number: int) = Interop.mkSliderAttr "selected" number
    static member inline children (e: ReactElement list) = unbox<IAwesomeSliderProperty>(prop.children e)
    static member inline create (props: IAwesomeSliderProperty list) =
        Interop.reactApi.createElement(reactAwesomeSlider, createObj !!props)