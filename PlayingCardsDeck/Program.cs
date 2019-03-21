using System;

namespace PlayingCardsDeck
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Deck consists of: (52 total playing cards), (4 suits), (13 playing cards per suit)";


            DeckManager deckManager = new DeckManager();

            foreach (PlayingCard card in deckManager.Deck)
            {
                Console.WriteLine(card.ToString());
            }

            // Tests go here for now
            Console.WriteLine();
            deckManager.DisplayDeckInfo();
            Console.WriteLine();

            Console.WriteLine("Now Removing One Card From The Top...");
            Console.WriteLine($"Removed: {deckManager.Deal().ToString()}");

            Console.WriteLine();
            deckManager.DisplayDeckInfo();
            Console.WriteLine();

            Console.WriteLine("Now Removing Five Cards From The Top...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Removed: {deckManager.Deal().ToString()}");
            }

            Console.WriteLine();
            deckManager.DisplayDeckInfo();
            Console.WriteLine();

            Console.WriteLine("Press any key to exit . . . ");
            Console.ReadKey(false);
        }
    }
}
