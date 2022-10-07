using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03.TextTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            StringBuilder output = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string str = Console.ReadLine();
            string wordToDecrypt = null;
            int count = 1;

            //reading from console
            while (str != "burp")
            {
                input.Append(str);
                str = Console.ReadLine();
            }

            //clearing whitespace
            for (int j = 0; j < input.Length - 1; j++)
            {
                if (input[j] == ' ')
                {
                    if (input[j + 1] == ' ')
                    {
                        input.Remove(j, 1);
                        j--;
                    }
                }
            }
            int dec = 0;
            string haha = Convert.ToString(input);
            for (int i = 0; i < haha.Length - 1; i++)
            {
            done:
                if (haha[i] == '$' && haha[i + 1] == '$')
                {
                    i++;
                }
                else if (haha[i] == '%' && haha[i + 1] == '%')
                {
                    i++;
                }
                else if (haha[i] == '&' && haha[i + 1] == '&')
                {
                    i++;
                }
                else if (haha[i] == '\'' && haha[i + 1] == '\'')
                {
                    i++;
                }
                else if (haha[i] == '$' && haha[i + 1] != '$')
                {
                    for (int j = i + 1; j < haha.Length; j++)
                    {
                        if (haha[j] == '$')
                        {
                            wordToDecrypt = haha.Substring(i + 1, j - (i + 1));
                            for (int k = 0; k < wordToDecrypt.Length; k++)
                            {
                                if (wordToDecrypt[k] != ' ')
                                {
                                    break;
                                }
                                else if (k == wordToDecrypt.Length - 1)
                                {
                                    i = j + 1;
                                    goto done;
                                }
                            }
                            char[] array = wordToDecrypt.ToCharArray();
                            i = j + 1;
                            for (int k = 0; k < array.Length; k++)
                            {
                                if (k % 2 == 0)
                                {
                                    dec = array[k] + 1;
                                    array[k] = (char)dec;
                                }
                                else
                                {
                                    dec = wordToDecrypt[k] - 1;
                                    array[k] = (char)dec;
                                }
                            }
                            for (int k = 0; k < array.Length; k++)
                            {
                                sb.Append(array[k]);
                            }
                            sb.Append(' ');
                            break;
                        }
                        count++;
                        if (count == 51)
                        {
                            break;
                        }
                    }
                }
                else if (haha[i] == '%' && haha[i + 1] != '%')
                {
                    for (int j = i + 1; j < haha.Length; j++)
                    {
                        if (haha[j] == '%')
                        {
                            wordToDecrypt = haha.Substring(i + 1, j - (i + 1));
                            for (int k = 0; k < wordToDecrypt.Length; k++)
                            {
                                if (wordToDecrypt[k] != ' ')
                                {
                                    break;
                                }
                                else if (k == wordToDecrypt.Length - 1)
                                {
                                    i = j + 1;
                                    goto done;
                                }
                            }
                            char[] array = wordToDecrypt.ToCharArray();
                            i = j + 1;
                            for (int k = 0; k < array.Length; k++)
                            {
                                if (k % 2 == 0)
                                {
                                    dec = array[k] + 2;
                                    array[k] = (char)dec;
                                }
                                else
                                {
                                    dec = wordToDecrypt[k] - 2;
                                    array[k] = (char)dec;
                                }
                            }
                            for (int k = 0; k < array.Length; k++)
                            {
                                sb.Append(array[k]);
                            }
                            sb.Append(' ');
                            break;
                        }
                        count++;
                        if (count == 51)
                        {
                            break;
                        }
                    }
                }
                else if (haha[i] == '&' && haha[i + 1] != '&')
                {
                    for (int j = i + 1; j < haha.Length; j++)
                    {
                        if (haha[j] == '&')
                        {
                            wordToDecrypt = haha.Substring(i + 1, j - (i + 1));
                            for (int k = 0; k < wordToDecrypt.Length; k++)
                            {
                                if (wordToDecrypt[k] != ' ')
                                {
                                    break;
                                }
                                else if (k == wordToDecrypt.Length - 1)
                                {
                                    i = j + 1;
                                    goto done;
                                }
                            }
                            char[] array = wordToDecrypt.ToCharArray();
                            i = j + 1;
                            for (int k = 0; k < array.Length; k++)
                            {
                                if (k % 2 == 0)
                                {
                                    dec = array[k] + 3;
                                    array[k] = (char)dec;
                                }
                                else
                                {
                                    dec = wordToDecrypt[k] - 3;
                                    array[k] = (char)dec;
                                }
                            }
                            for (int k = 0; k < array.Length; k++)
                            {
                                sb.Append(array[k]);
                            }
                            sb.Append(' ');
                            break;
                        }
                        count++;
                        if (count == 51)
                        {
                            break;
                        }
                    }
                }
                else if (haha[i] == '\'' && haha[i + 1] != '\'')
                {
                    for (int j = i + 1; j < haha.Length; j++)
                    {
                        if (haha[j] == '\'')
                        {
                            wordToDecrypt = haha.Substring(i + 1, j - (i + 1));
                            for (int k = 0; k < wordToDecrypt.Length; k++)
                            {
                                if (wordToDecrypt[k] != ' ')
                                {
                                    break;
                                }
                                else if (k == wordToDecrypt.Length - 1)
                                {
                                    i = j + 1;
                                    goto done;
                                }
                            }
                            char[] array = wordToDecrypt.ToCharArray();
                            i = j + 1;
                            for (int k = 0; k < array.Length; k++)
                            {
                                if (k % 2 == 0)
                                {
                                    dec = array[k] + 4;
                                    array[k] = (char)dec;
                                }
                                else
                                {
                                    dec = wordToDecrypt[k] - 4;
                                    array[k] = (char)dec;
                                }
                            }
                            for (int k = 0; k < array.Length; k++)
                            {
                                sb.Append(array[k]);
                            }
                            sb.Append(' ');
                            break;
                        }
                        count++;
                        if (count == 51)
                        {
                            break;
                        }
                    }
                }
                count = 1;
            }
            Console.WriteLine(sb);
        }
    }
}