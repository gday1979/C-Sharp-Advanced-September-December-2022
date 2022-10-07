using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input.Contains("->"))
                {
                    string[] tokens = input.Split(" -> ");
                    string user = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if (users.ContainsKey(user) == false)
                    {
                        users.Add(user, new Dictionary<string, int>());
                    }

                    if (users[user].ContainsKey(tag) == false)
                    {
                        users[user].Add(tag, 0);
                    }

                    users[user][tag] = likes;


                }
                else
                {
                    string[] tokens = input.Split();
                    if (users.ContainsKey(tokens[1]))
                    {
                        users.Remove(tokens[1]);
                    }
                }
            }

            foreach (var kvp in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count()))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var pair in kvp.Value)
                {
                    Console.WriteLine($"- {pair.Key}: {pair.Value}");
                }
            }
        }
    }
}