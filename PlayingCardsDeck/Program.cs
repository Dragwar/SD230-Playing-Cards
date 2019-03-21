﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "Deck consists of: (52 total playing cards), (4 suits), (13 playing cards per suit)";

            DeckManager deck = new DeckManager();
            foreach (var item in deck.Deck)
            {
                Console.WriteLine($"{item.Name} - {item.Suit} - {item.Value}");
            }
            Console.WriteLine();

            // Tests go here for now

            Console.ReadKey(false);
        }
    }
}
