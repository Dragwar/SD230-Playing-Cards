using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Program
    {
        static void Main()
        {
            List<int> c = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            c.Display();
            var b = c.ToList();
            b.Reverse();
            b.Display();
            List<int> a = b.Shuffle().Display();

            Deck deck = new Deck();
            foreach (var item in deck.Cards)
            {
                Console.WriteLine($"{item.Name} - {item.Suit} - {item.Value}\n");
            }
            Console.ReadLine();
        }
    }
}
