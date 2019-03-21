namespace PlayingCardsDeck
{
    public class PlayingCard
    {
        public CardsEnum Name { get; set; }
        public SuitEnum Suit { get; set; }
        public int Value { get => (int)Name; }
    }
}
