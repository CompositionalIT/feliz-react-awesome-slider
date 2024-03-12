module App

open Elmish
open Elmish.React
open Fable.Core.JsInterop

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

importSideEffects "./styles/global.scss"

Program.mkProgram Index.init Index.update Index.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "feliz-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
