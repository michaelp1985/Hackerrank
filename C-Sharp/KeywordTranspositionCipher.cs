using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution
    {
        static void Main(string[] args)
        {
            int cases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < cases; i++)
            {
                string input = Console.ReadLine();
                byte[] key = Encoding.ASCII.GetBytes(input).Distinct().ToArray();
                byte[][] cipher;
                byte[] secretDecoderRing = new byte[26];                
                int extraCols = 26 % key.Length;
                int cypherLength = 26/key.Length;
                cipher = new byte[key.Length][];

                // - Define the size of each array that resides within the "cipher" array
                for (int r = 0; r < key.Length; r++)
                {
                    if (r < extraCols)
                        cipher[r] = new byte[cypherLength + 1];
                    else
                        cipher[r] = new byte[cypherLength];
                }

                // - Populate the first position of each array with the correct key char
                for (int k = 0; k < key.Length; k++)
                {
                    cipher[k][0] = key[k];
                }

                byte a = 65;

                // - Populate all the remaining positions of the cipher with the correct ascII byte value
                while (a < 91)
                {
                    for (int r = 0; r < cypherLength; r++)
                    {
                        for (int c = 0; c < key.Length; c++)
                        {

                            if (!key.Contains(a))
                            {
                                cipher[c][r + 1] = a;
                            }
                            else
                            {
                                c--;
                            }

                            a++;

                            if (a > 90)
                                break;
                        }

                        if (a > 90)
                            break;
                    }
                }

                // - Shift the cols in alphabetical order
                byte[] temp;
                int index = 0;

                // - Sort the arrray of arrays using the insertion sort algorithm 
                for (int f = 1, l = 1; l < cipher.Length; l++)
                {
                    temp = cipher[l];
                    f = l;
                    while (f > 0 && cipher[f - 1][0] >= temp[0])
                    {
                        cipher[f] = cipher[f - 1];
                        f -= 1;
                    }

                    cipher[f] = temp;
                }
                               
                // - Populate the decoderring with the values from the cipher
                for (int r = 0; r < cipher.Length; r++)
                {
                    for (int c = 0; c < cipher[r].Length; c++)
                    {
                        if (cipher[r][c] == 0)
                            continue;
                        secretDecoderRing[index] = cipher[r][c];
                        index++;
                    }
                }

                // - Read in the secert message
                input = Console.ReadLine();               
                char[] crypt = input.ToCharArray();
                string output = "";

                // - De-cipher the message
                foreach (char c in crypt)
                {
                    if (c == ' ')
                        output += " ";
                    else
                    {
                        byte t = (byte)c;

                        t -= 65;

                        output += (char)(Array.IndexOf(secretDecoderRing, (byte)c) + 65);
                    }
                }

                // - Output the message
                Console.WriteLine(output);                
            }
        }
    }
