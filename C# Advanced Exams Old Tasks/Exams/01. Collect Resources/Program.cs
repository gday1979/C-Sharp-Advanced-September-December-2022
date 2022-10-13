using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Collect_Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] resources = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> collectedResources = new List<string>();
            int paths = int.Parse(Console.ReadLine());
            int startIndex = 0;
            int step = 0;
            int quanity = 0;
            int maxQuanity = int.MinValue;
            bool isCollected = false;

            for (int i = 0; i < paths; i++)
            {
                string[] input = Console.ReadLine().Split();
                startIndex = Convert.ToInt32(input[0]);
                step = Convert.ToInt32(input[1]);
                string currentResouce = null;
                int currentQuanity = 0;
                for (int j = startIndex; j < resources.Length; j += step)
                {
                done:
                    if (collectedResources.Contains(j + resources[j]))
                    {
                        break;
                    }
                    int separator = resources[j].IndexOf("_");
                    if (separator != -1)
                    {
                        currentResouce = resources[j].Substring(0, separator);
                        currentQuanity = Convert.ToInt32(resources[j].Substring(separator + 1));
                    }
                    else
                    {
                        currentResouce = resources[j];
                        currentQuanity = 1;
                    }
                    switch (currentResouce)
                    {
                        case "stone":
                            quanity += currentQuanity;
                            isCollected = true;
                            break;
                        case "gold":
                            quanity += currentQuanity;
                            isCollected = true;
                            break;
                        case "wood":
                            quanity += currentQuanity;
                            isCollected = true;
                            break;
                        case "food":
                            quanity += currentQuanity;
                            isCollected = true;
                            break;
                    }
                    if (isCollected)
                    {
                        collectedResources.Add(j + resources[j]);
                    }
                    isCollected = false;
                    if (j + step > resources.Length - 1)
                    {
                        for (int k = 0; k < step; k++)
                        {
                            if (j == resources.Length - 1)
                            {
                                j = 0;
                            }
                            else
                            {
                                j++;
                            }
                        }
                        goto done;
                    }
                }
                if (quanity > maxQuanity)
                {
                    maxQuanity = quanity;
                }
                quanity = 0;
                collectedResources.Clear();
            }
            Console.WriteLine(maxQuanity);
        }
    }
}