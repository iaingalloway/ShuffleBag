namespace ShuffleBag.Console
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            var cards = suits.SelectMany(
                suit => ranks,
                (suit, rank) => new Card(suit, rank));

            var deck = cards.Shuffle();

            var hand = deck.Take(5);

            foreach (var card in hand)
            {
                Console.WriteLine(
                    "You drew the {0} of {1}!",
                    card.Rank,
                    card.Suit);
            }

            Console.ReadKey();
        }
    }
}
