type AuctionId = AuctionId of int

type Password = Password of string

type Profile = Profile of string //whatever

type FrontendUser = {
    Password: Password
}

type FacebookUser = {
    Profile: Profile
}

type User = 
    | FrontendUser of Password
    | FacebookUser of Profile

type AuctionState =
    | Active
    | Pending
    | Finished

type Auction = { 
    Id: AuctionId; 
    User: User; 
    State: AuctionState
}

let baseAuction = {
    Id = AuctionId 1;
    User = FrontendUser (Password "123456");
    State = Active;
}

type MainOfferAuction = MainOfferAuction of Auction

type AuctionOfUser = 
    | NormalAuction of Auction
    | MainAuction of MainOfferAuction

type OnlineUser = {
    User: User;
    Auctions: AuctionOfUser list;
}

let createAuction (isMain:bool) =
    match isMain with
    | true -> MainAuction (MainOfferAuction baseAuction)
    | false -> NormalAuction baseAuction

[<EntryPoint>]
let main argv = 
    
    let oneUser = {
        User = FrontendUser (Password "123456");
        Auctions = List.singleton (createAuction true)
    }

    System.Console.ReadKey() |> ignore
    0