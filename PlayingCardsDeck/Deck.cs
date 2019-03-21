using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PlayingCardsDeck
{
    /// <summary>
    ///     <para/>Holds Cards that can be dealt and shuffled,
    ///     <para/>Static SortedPlayingCards represents the Cards before it got shuffled
    ///     <para/>Classes Actions:
    ///     <para/>- Cards will be shuffled on Deck creation
    ///     <para/>- Cards can be shuffled after Deck creation
    ///     <para/>- Cards can be dealt one at a time
    ///     <para/>- Cards can be dealt all at once
    /// </summary>
    public class Deck
    {
        public Deck(int numberOfInitialShuffles = 5)
        {
            Cards = BuildDeck().Shuffle(numberOfInitialShuffles);
        }

        /// <summary>
        ///     Instead of using BuildDeck() to see the default deck you can use this property
        /// </summary>
        public static List<PlayingCard> SortedPlayingCards { get; } = new List<PlayingCard>(BuildDeck());

        /// <summary>
        ///     Represents all the playing cards in the deck
        /// </summary>
        public List<PlayingCard> Cards { get; private set; }


        /// <summary>
        ///     Shuffles the cards
        /// </summary>
        /// <param name="numberOfShuffles">(Optional) Represents the number of times the deck will be shuffled</param>
        public void ShuffleDeck([Optional] int? numberOfShuffles)
        {
            Cards = Cards.Shuffle(numberOfShuffles);
        }


        /// <summary>
        ///     Resets Cards to initial state (52 shuffled Cards)
        /// </summary>
        /// <param name="numberOfShuffles">(Optional) Represents the number of times the deck will be shuffled</param>
        public void ResetToNewShuffledDeck([Optional] int? numberOfShuffles)
        {
            Cards = BuildDeck().Shuffle(numberOfShuffles);
        }


        /// <summary>
        ///     <para/>Deals one card from the top "Cards[0]" (unless optional parameter was used)
        ///     <para/>Before dealing the card, the card will be removed from Cards, then it will be dealt
        /// </summary>
        /// <param name="takeCardAt">(Optional) Deal card from a certain index</param>
        /// <returns>Returns the card that was dealt</returns>
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


        /// <summary>
        ///     <para/>Deals all cards if there are any left, then removes all cards from the Cards list.
        ///     <para/>Lastly, this method will return the cards that were removed
        /// </summary>
        /// <returns>Returns the current state of the Cards</returns>
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


        /// <summary>
        ///     <para/>Used to get a sorted list of 52 playing cards
        ///     <para/>(4 suits and 13 cards in each suit) unless Suit/CardsEnum was changed
        /// </summary>
        /// <returns>Returns a sorted list of playing cards</returns>
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
    }
}
