namespace ShuffleBag.Console
{
    public struct Card
    {
        private readonly Suit suit;

        private readonly Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public Rank Rank
        {
            get { return this.rank; }
        }

        public Suit Suit
        {
            get { return this.suit; }
        }
    }
}
