using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Deck
    {
        public static List<PlayingCard> SortedPlayingCards { get; } = new List<PlayingCard>(BuildDeck());

        public List<PlayingCard> Cards { get; set; }

        public Deck()
        {
            Cards = BuildDeck();
        }


        private static List<PlayingCard> BuildDeck()
        {
            var suits = Enum.GetValues(typeof(SuitEnum));
            var cards = Enum.GetValues(typeof(CardsEnum));

            List<PlayingCard> playingCards = new List<PlayingCard>();

            foreach (var suit in suits)
            {
                foreach (var card in cards)
                {
                    playingCards.Add(new PlayingCard((CardsEnum)card, (SuitEnum)suit));
                }
            }

            return playingCards;
        }


        public PlayingCard DealCard()
        {
            throw new NotImplementedException();
        }

        public PlayingCard DealAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
