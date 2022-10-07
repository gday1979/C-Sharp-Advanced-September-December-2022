using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4.Events
{
    class Program
    {
        static void Main(string[] args)
        {
            int eventNumbers = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<DateTime>>> database = new Dictionary<string, Dictionary<string, List<DateTime>>>();
            bool isName = false;
            bool isCity = false;
            bool isTime = false;
            for (int i = 0; i < eventNumbers; i++)
            {
                string city = null;
                string name = null;
                string time = null;
                DateTime time2 = new DateTime();
                string input = Console.ReadLine();
                string[] input2 = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //validation
                if (input2.Length <= 3)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (input[j] == '#')
                        {
                            for (int k = j + 1; k < input.Length; k++)
                            {
                                if (Char.IsLetter(input[k]))
                                {
                                    isName = true;
                                }
                                else if (input[k] == ':')
                                {
                                    name = input.Substring(j + 1, k - 1);
                                    j = k;
                                    break;
                                }
                                else
                                {
                                    isName = false;
                                    j = k;
                                    break;
                                }
                            }
                        }
                        else if (input[j] == '@')
                        {
                            int cont = 0;
                            for (int k = j + 1; k < input.Length; k++)
                            {
                                if (Char.IsLetter(input[k]))
                                {
                                    isCity = true;
                                    cont++;
                                }
                                else if ((Char.IsDigit(input[k]) && Char.IsDigit(input[k + 1])) || input[k] == ' ')
                                {
                                    city = input.Substring(j + 1, cont);
                                    j = k;
                                    if (Char.IsDigit(input[k]))
                                    {
                                        j = k - 1;
                                    }
                                    else
                                    {
                                        j = k;
                                    }
                                    break;
                                }
                                else
                                {
                                    isCity = false;
                                    break;
                                }
                            }
                        }
                        else if (Char.IsDigit(input[j]) &&
                            Char.IsDigit(input[j + 1]) &&
                            input[j + 2] == ':' &&
                            Char.IsDigit(input[j + 3]) &&
                            Char.IsDigit(input[j + 4]) &&
                            input[j + 4] == input.Last())
                        {
                            isTime = true;
                            time = input.Substring(j, 5);
                            break;
                        }
                        else if (input[0] != '#')
                        {
                            break;
                        }
                    }
                }
                if (DateTime.TryParse(time, out time2))
                {
                    isTime = true;
                }
                else
                {
                    isTime = false;
                }
                //database adding
                if (isTime && isName && isCity)
                {
                    if (database.ContainsKey(city))
                    {
                        if (database[city].ContainsKey(name))
                        {
                            database[city][name].Add(DateTime.Parse(time));
                        }
                        else
                        {
                            database[city].Add(name, new List<DateTime>());
                            database[city][name].Add(DateTime.Parse(time));
                        }
                    }
                    else
                    {
                        database.Add(city, new Dictionary<string, List<DateTime>>());
                        database[city].Add(name, new List<DateTime>());
                        database[city][name].Add(DateTime.Parse(time));
                    }
                }
                isTime = false;
                isCity = false;
                isName = false;
            }
            List<string> displayCity = new List<string>(Console.ReadLine().Split(',').ToArray());
            displayCity.Sort();
            for (int i = 0; i < displayCity.Count; i++)
            {
                if (database.ContainsKey(displayCity[i]))
                {
                    var sortedCity = database.Where(c => c.Key == displayCity[i]);
                    foreach (var citys in sortedCity)
                    {
                        Console.WriteLine("{0}:", citys.Key);
                        int countNames = 1;
                        foreach (var names in citys.Value.OrderBy(x => x.Key))
                        {
                            Console.Write("{1}. {0} -> ", names.Key, countNames);
                            int countTimes = 0;
                            foreach (var times in names.Value.OrderBy(h => h.Hour).ThenBy(m => m.Minute))
                            {
                                countTimes++;
                                if (countTimes == names.Value.Count)
                                {
                                    Console.Write("{0:D2}:{1:D2}", times.Hour, times.Minute);
                                }
                                else
                                {
                                    Console.Write("{0:D2}:{1:D2}, ", times.Hour, times.Minute);
                                }

                            }
                            countNames++;
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
