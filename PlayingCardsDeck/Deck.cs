using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PlayingCardsDeck
{
    public class Deck
    {
        public static List<PlayingCard> SortedPlayingCards { get; } = new List<PlayingCard>(BuildDeck());

        public List<PlayingCard> Cards { get; private set; }

        public Deck(int numberOfShuffles = 5)
        {
            Cards = BuildDeck().Shuffle(numberOfShuffles);
        }


        private static List<PlayingCard> BuildDeck()
        {
            Array suits = Enum.GetValues(typeof(SuitEnum));
            Array cards = Enum.GetValues(typeof(CardsEnum));

            List<PlayingCard> playingCards = new List<PlayingCard>();

            foreach (int suit in suits)
            {
                foreach (int card in cards)
                {
                    playingCards.Add(new PlayingCard((CardsEnum)card, (SuitEnum)suit));
                }
            }

            return playingCards;
        }


        public void RebuildShuffledDeck(int? numberOfShuffles)
        {
            Cards = BuildDeck().Shuffle(numberOfShuffles);
        }

        public PlayingCard Deal([Optional] int? takeCardAt)
        {
            if (Cards.Any())
            {
                takeCardAt = takeCardAt ?? 0;
                takeCardAt = takeCardAt > Cards.Count ? Cards.Count - 1 : takeCardAt;
                PlayingCard card = Cards[takeCardAt.Value];
                Cards.RemoveAt(takeCardAt.Value);
                return card;
            }
            else if (!Cards.Any())
            {
                Console.WriteLine("No cards were left to deal!");
                return null;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }

        public List<PlayingCard> DealAll()
        {
            if (Cards.Any())
            {
                List<PlayingCard> cards = new List<PlayingCard>(Cards);
                Cards.Clear();
                return cards;
            }
            else if (!Cards.Any())
            {
                Console.WriteLine("No cards were left to deal!");
                return null;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
