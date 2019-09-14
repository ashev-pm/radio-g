namespace Feed.DomainModel

module Model = 
    type Content = 
        Message of string
        | Picture of string
        | Gif of string

open Model

module API =
    let save (content:Content) =
        printfn "%O" content