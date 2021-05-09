module Feliz.ReactAwesomeSlider

open Fable.Core
open Fable.Core.JsInterop
open Feliz

let reactAwesomeSlider: obj = importDefault "react-awesome-slider"
let withAutoPlay: (obj -> obj) = importDefault "react-awesome-slider/dist/autoplay"

importAll "react-awesome-slider/dist/custom-animations/cube-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fall-animation.css"
importAll "react-awesome-slider/dist/custom-animations/fold-out-animation.css"
importAll "react-awesome-slider/dist/custom-animations/open-animation.css"
importAll "react-awesome-slider/dist/custom-animations/scale-out-animation.css"
importAll "react-awesome-slider/dist/styles.css"


[<Erase>]
type IAwesomeSliderProperty = interface end

[<Erase>]
type IAutoplaySliderProperty = interface end

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

    static member inline name (s: string) = unbox<IAwesomeSliderProperty>("name" ==> s)

    static member inline bullets (b: bool) = "bullets" => b
    static member inline organicArrows (b: bool) = "organicArrows" => b
    static member inline fillParent (b: bool) = "fillParent" => b
    static member inline infinite (b: bool) = "infinite" => b
    static member inline mobileTouch (b: bool) = "mobileTouch" => b
    static member inline buttons (b: bool) = "buttons" => b
    static member inline startup (b: bool) = "startup" => b

    static member inline startupScreen (element: ReactElement) = "startupScreen" => element
    static member inline buttonContentRight (element: ReactElement) = "buttonContentRight" => element
    static member inline customContent (element: ReactElement) = "customContent" => element


    static member inline selected (number: int) = "selected" => number
    static member inline transitionDelay (number: int) = "transitionDelay" => number
    static member inline children (e: ReactElement list) = unbox<IAwesomeSliderProperty>(prop.children e)
    static member inline create (props: IAwesomeSliderProperty list) =
        Interop.reactApi.createElement(reactAwesomeSlider, createObj !!props)


type AutoplaySlider =

    static member inline play (b: bool) = unbox<IAutoplaySliderProperty>("play" ==> b)
    static member inline cancelOnInteraction (b: bool) = unbox<IAutoplaySliderProperty>("cancelOnInteraction" ==> b)

    static member inline interval (i: int) = unbox<IAutoplaySliderProperty>("interval" ==> i)

    static member inline children (e: ReactElement list) = unbox<IAutoplaySliderProperty>(prop.children e)

    static member inline animation (a: Animation) = unbox<IAutoplaySliderProperty>("animation" ==> (Animation.toJSValue a))

    static member inline name (s: string) = unbox<IAutoplaySliderProperty>("name" ==> s)

    static member inline bullets (b: bool) = unbox<IAutoplaySliderProperty>("bullets" ==> b)
    static member inline organicArrows (b: bool) = unbox<IAutoplaySliderProperty>("organicArrows" ==> b)
    static member inline fillParent (b: bool) = unbox<IAutoplaySliderProperty>("fillParent" ==> b)
    static member inline infinite (b: bool) = unbox<IAutoplaySliderProperty>("infinite" ==> b)
    static member inline mobileTouch (b: bool) = unbox<IAutoplaySliderProperty>("mobileTouch" ==> b)
    static member inline buttons (b: bool) = unbox<IAutoplaySliderProperty>("buttons" ==> b)
    static member inline startup (b: bool) = unbox<IAutoplaySliderProperty>("startup" ==> b)

    static member inline startupScreen (element: ReactElement) = unbox<IAutoplaySliderProperty>("startupScreen" ==> element)
    static member inline buttonContentRight (element: ReactElement) = unbox<IAutoplaySliderProperty>("buttonContentRight" ==> element)
    static member inline customContent (element: ReactElement) = unbox<IAutoplaySliderProperty>("customContent" ==> element)


    static member inline selected (number: int) = unbox<IAutoplaySliderProperty>("selected" ==> number)
    static member inline transitionDelay (number: int) = unbox<IAutoplaySliderProperty>("transitionDelay" ==> number)

    static member inline create (props: IAutoplaySliderProperty list) =
        let autoplaySlider = withAutoPlay(reactAwesomeSlider)
        Interop.reactApi.createElement(autoplaySlider, createObj !!props)
