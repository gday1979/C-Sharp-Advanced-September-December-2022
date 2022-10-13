using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> database = new Dictionary<string, Dictionary<string, long>>();

            string veniu = null;
            string singer = null;
            long ticketPrice = int.MinValue;
            long ticketCount = int.MinValue;

            string input = Console.ReadLine().Trim();
            while (input != "End")
            {
                //Validation..
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == ' ' && input[i + 1] == '@')
                    {
                        singer = input.Substring(0, i);
                    }
                    if (input[i] == '@' && Char.IsLetter(input[i + 1]))
                    {
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            if (input[j] == ' ' && Char.IsDigit(input[j + 1]))
                            {
                                veniu = input.Substring(i + 1, j - (i + 1));
                                break;
                            }
                        }
                    }
                    if (input[i] == ' ' && Char.IsDigit(input[i + 1]))
                    {
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            if (input[j] == ' ' && Char.IsDigit(input[j + 1]))
                            {
                                ticketPrice = Convert.ToInt64(input.Substring(i + 1, j - (i + 1)));
                                ticketCount = Convert.ToInt64(input.Substring(j + 1, input.Length - (j + 1)));
                                break;
                            }
                        }
                        break;
                    }
                }
                //end of validation
                if (veniu != null && singer != null && ticketPrice != int.MinValue && ticketCount != int.MinValue)
                {
                    long moneyMade = ticketPrice * ticketCount;
                    if (database.ContainsKey(veniu))
                    {
                        if (database[veniu].ContainsKey(singer))
                        {
                            long totalMoney = database[veniu][singer] + moneyMade;
                            database[veniu][singer] = totalMoney;
                        }
                        else
                        {
                            database[veniu].Add(singer, moneyMade);
                        }
                    }
                    else
                    {
                        database.Add(veniu, new Dictionary<string, long>());
                        database[veniu].Add(singer, moneyMade);
                    }
                }
                veniu = null;
                singer = null;
                ticketPrice = int.MinValue;
                ticketCount = int.MinValue;
                input = Console.ReadLine();
            }


            foreach (var veniui in database)
            {
                Console.WriteLine(veniui.Key);
                foreach (var singerr in veniui.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singerr.Key, singerr.Value);
                }
            }
        }
    }
}