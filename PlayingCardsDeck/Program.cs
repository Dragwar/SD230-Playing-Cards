using System;
using System.Linq;

namespace PlayingCardsDeck
{
    public class Program
    {
        static void Main()
        {
            int[] deck = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            deck.Display();
            var b = deck.ToList();
            b.Reverse();
            b.ToArray().Display();
            int[] a = b.ToArray().Shuffle().Display();
        }
    }
}
