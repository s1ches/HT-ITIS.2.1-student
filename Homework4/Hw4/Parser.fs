﻿module Hw4.Parser

open System
open Microsoft.FSharp.Core
open Hw4.CalcOptions
open Hw4.CalculatorOperations

let isArgLengthSupported (args : string[]) =
    args.Length = 3
    
let parseFloat (arg : string) = 
    match Double.TryParse arg  with
        | true, v -> v  
        | false, _ -> ArgumentException($"Expected number, was given {arg}") |> raise
        
let parseOperation (arg : string) =
    match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> ArgumentException($"Expected +, -, * or /, was given {arg}") |> raise
    
let parseCalcArguments(args : string[]) =
    match isArgLengthSupported args with
    | false -> ArgumentException($"Need 3 arguments, was given {args.Length}") |> raise
    | true -> { arg1 = args[0] |> parseFloat
                arg2 = args[2] |> parseFloat
                operation = args[1] |> parseOperation }
