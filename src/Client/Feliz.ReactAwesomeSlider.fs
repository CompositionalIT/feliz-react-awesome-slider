module ReactAwesomeSlider

open Fable.Core
open Fable.Core.JsInterop
open Feliz

let reactAwesomeSlider: obj = importDefault "react-awesome-slider"

importAll "react-awesome-slider/dist/custom-animations/cube-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fall-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fold-out-animation.css"
importAll "react-awesome-slider/dist/custom-animations/open-animation.css"
importAll "react-awesome-slider/dist/custom-animations/scale-out-animation.css"
importAll "react-awesome-slider/dist/styles.css"


[<Erase>]
type IAwesomeSliderProperty = interface end


type Animation =
    | FoldOutAnimation
    | CubeAnimation
    | FallAnimation
    | OpenAnimation
    | ScaleOutAnimation
    with static member toJSValue = function
            | FoldOutAnimation -> "foldOutAnimation"
            | CubeAnimation -> "cubeAnimation"
            | FallAnimation -> "fallAnimation"
            | OpenAnimation -> "openAnimation"
            | ScaleOutAnimation -> "scaleOutAnimation"

let (=>) key value = unbox<IAwesomeSliderProperty>(key ==> value)

type AwesomeSlider =
    static member inline animation (a: Animation) = "animation" => (Animation.toJSValue a)

    static member inline name (s: string) = "name" => s

    static member inline bullets (b: bool) = "bullets" => b
    static member inline organicArrows (b: bool) = "organicArrows" => b
    static member inline fillParent (b: bool) = "fillParent" => b
    static member inline infinite (b: bool) = "infinite" => b
    static member inline mobileTouch (b: bool) = "mobileTouch" => b
    static member inline buttons (b: bool) = "buttons" => b


    static member inline selected (number: int) = "selected" => number
    static member inline transitionDelay (number: int) = "transitionDelay" => number
    static member inline children (e: ReactElement list) = unbox<IAwesomeSliderProperty>(prop.children e)
    static member inline create (props) =
        Interop.reactApi.createElement(reactAwesomeSlider, createObj !!props)