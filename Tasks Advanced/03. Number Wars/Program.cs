using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    class Program
    {
        static char[] alpha;
        static void Main(string[] args)
        {
            Queue<string> deck1 = new Queue<string>(Console.ReadLine().Split());
            Queue<string> deck2 = new Queue<string>(Console.ReadLine().Split());


            alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int turns = 0;

            while (turns < 1000000 && deck1.Count > 0 && deck2.Count > 0)
            {
                turns++;
                string card1 = deck1.Dequeue();
                string card2 = deck2.Dequeue();

                int number1 = int.Parse(card1.Substring(0, card1.Length - 1));
                int number2 = int.Parse(card2.Substring(0, card2.Length - 1));

                if (number1 > number2)
                {
                    deck1.Enqueue(card1);
                    deck1.Enqueue(card2);
                }
                else if (number1 < number2)
                {
                    deck2.Enqueue(card1);
                    deck2.Enqueue(card2);
                }
                else if (number1 == number2)
                {
                    List<string> cards = new List<string>();
                    int sum1 = 0;
                    int sum2 = 0;

                    while (sum1 == sum2)
                    {
                        sum1 = CalculateSumOfCards(deck1, cards);
                        sum2 = CalculateSumOfCards(deck2, cards);



                        if (sum1 > sum2)
                        {
                            foreach (string card in cards)
                            {
                                deck1.Enqueue(card);
                            }
                        }
                        else if (sum1 < sum2)
                        {
                            foreach (string card in cards)
                            {
                                deck1.Enqueue(card);
                            }
                        }

                        if (deck1.Count == 0 && deck2.Count == 0)
                        {
                            Console.WriteLine($"Draw after {turns} turns");
                            return;
                        }
                    }
                }

            }

            string winner = deck1.Count > 0 ? "First" : "Second";

            Console.WriteLine($"{winner} player wins after {turns} turns");
        }

        private static int CalculateSumOfCards(Queue<string> deck, List<string> cards)
        {
            int sum = 0;

            for (int counter = 0; counter < 3; counter++)
            {

                if (deck.Count > 0)
                {
                    string card = deck.Dequeue();
                    cards.Add(card);
                    char symbol = card[card.Length - 1];

                    sum += Array.IndexOf(alpha, alpha.Where(x => x == symbol).FirstOrDefault());
                }
            }

            return sum;

        }
    }
}