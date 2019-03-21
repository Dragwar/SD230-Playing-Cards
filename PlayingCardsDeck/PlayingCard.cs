namespace PlayingCardsDeck
{
    public class PlayingCard
    {
        public CardsEnum Name { get; }
        public SuitEnum Suit { get; }
        public int Value { get => (int)Name; }

        public PlayingCard(CardsEnum name, SuitEnum suit)
        {
            Name = name;
            Suit = suit;
        }
    }
}
