# ShuffleBag
A simple shuffled collection implementation in C# using the Fisher-Yates algorithm.

## How to get it?

    PM> Install-Package ShuffleBag

## How to use it?

Just add `using ShuffleBag` and you can easily shuffle collections:-

    var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
    var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

    var cards = suits.SelectMany(
        suit => ranks,
        (suit, rank) => new Card(suit, rank)); // Cards not included!

    var deck = cards.Shuffle(); // Easily shuffle collections
    var hand = deck.Take(5);

    var reshufflingDeck = cards.ShuffleIndefinitely() // "Reshuffle" when empty
    var reallyBigHand = deck.Take(104);
