using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Program
    {
        static void Main()
        {
            Deck deck = new Deck();
            foreach (var item in deck.Cards)
            {
                Console.WriteLine($"{item.Name} - {item.Suit} - {item.Value}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
