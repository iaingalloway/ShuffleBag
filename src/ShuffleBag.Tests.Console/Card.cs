namespace ShuffleBag.Tests.Console
{
    public struct Card
    {
        private readonly Rank rank;

        private readonly Suit suit;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public Rank Rank
        {
            get
            {
                return this.rank;
            }
        }

        public Suit Suit
        {
            get
            {
                return this.suit;
            }
        }
    }
}
