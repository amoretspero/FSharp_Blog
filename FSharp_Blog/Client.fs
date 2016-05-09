namespace FSharp_Blog

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client =

    let Main () =
        let rvInput = Var.Create ""
        let submit = Submitter.CreateOption rvInput.View
        let vReversed =
            submit.View.MapAsync(function
                | None -> async { return "" }
                | Some input -> Server.DoSomething input
            )
        div [
            Doc.Input [] rvInput
            Doc.Button "Send" [] submit.Trigger
            hr []
            h4Attr [attr.``class`` "text-muted"] [text "The server responded:"]
            divAttr [attr.``class`` "jumbotron"] [h1 [textView vReversed]]
        ]

    let PersonalInfo (age : int) =
        let age = age
        let ageKorean = System.DateTime.Now.Year - 1994 + 1
        let favoritePL = [| "F#"; "C#" |]
        let likes = [| "Piano"; "Coffee"; "Macarons"; "F# learning"; "Taking photos"; "Facebook"; "KakaoTalk" |]
        let quote = "Live as if you were to die tomorrow. Learn as if you were to live forever."
        div [
            h4Attr ([(attr.style "padding: 10px 20px; font-family:Malgun Gothic;")] |> Seq.ofList) ([(text "About Me")] |> Seq.ofList)
            div [
                dlAttr [(attr.``class`` "dl-horizontal")] [
                    dt [
                        (text "Name")
                    ]
                    ddAttr [(attr.style "margin-bottom: 10px;")] [
                        (text "Jiung Hahm")
                    ]
                    dt [
                        (text "Birth")
                    ]
                    ddAttr [(attr.style "margin-bottom: 10px;")] [
                        (text "1994-07-07")
                    ]
                    dt [
                        (text "Age")
                    ]
                    ddAttr [(attr.style "margin-bottom: 10px;")] [
                        (text (age.ToString() + " (In Korean : " + ageKorean.ToString() + ")"))
                    ]
                    dt [
                        (text "Likes")
                    ]
                    ddAttr [(attr.style "margin-bottom: 10px;")] [
                        (text (String.concat ", " likes))
                    ]
                    dt [
                        (text "Favorite PLs")
                    ]
                    ddAttr [(attr.style "margin-bottom: 10px;")] [
                        (text (String.concat ", " favoritePL))
                    ]
                    blockquoteAttr [(attr.``class`` "col-md-12"); (attr.style "padding: 30px 20px")] [
                        p [
                            (text quote)
                        ]
                        footer [
                            (text "Mahatma Gandhi")
                        ]
                    ]
                ]
            ]
        ]
