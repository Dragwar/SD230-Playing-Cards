using System;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Program
    {
        static void Main()
        {
            int[] c = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            c.Display();
            var b = c.ToList();
            b.Reverse();
            b.ToArray().Display();
            int[] a = b.ToArray().Shuffle().Display();

            Deck deck = new Deck();
            foreach (var item in deck.Cards)
            {
                Console.WriteLine($"{item.Name} - {item.Suit} - {item.Value}\n");
            }
            Console.ReadLine();
        }
    }
}
