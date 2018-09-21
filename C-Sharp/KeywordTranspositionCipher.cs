/*
A keyword transposition cipher is a method of choosing a monoalphabetic substitution to encode a 
message. The substitution alphabet is determined by choosing a keyword, arranging the remaining 
letters of the alphabet in columns below the letters of the keyword, and then reading back the 
columns in the alphabetical order of the letters of the keyword. 

For instance, if one chose the keyword SECRET, the columns generated would look like the 
following diagram. Note how the letters in the keyword are skipped when laying out the columns,
and duplicate letters are removed from the keyword:
SECRT
ABDFG
HIJKL
MNOPQ
UVWXY
Z

Since the alphabetical order of the characters in the keyword is CERST, 
the columns are then rearranged based on the first row. 
Then, the letters are read column-wise to get the substitution cipher as shown below:
CERST         CDJOW
DBFAG         EBINV
JIKHL    =>   RFKPX
ONPMQ         SAHMUZ
WVXUY         TGLQY
   Z
   
After that, we match the order to the alphabet to get: 
Original:     ABCDE FGHIJ KLMNO PQRSTU VWXYZ
Substitution: CDJOW EBINV RFKPX SAHMUZ TGLQY

Task
Given a piece of ciphertext and the keyword used to encipher it, 
write an algorithm to output the original message with the keyword transposition 
cipher described above.

Input Format
The first line of input will be an integer N(1<=N<=10) indicating the number of test cases to follow. 
For each test case in N, two additional lines will follow, one containing the keyword, 
and one containing the ciphertext, respectively. 
The keyword will be, at most, 7 characters long, and the ciphertext will be, at most, 255 characters 
in length (all uppercase).

Output Format
Output the decoded version of the ciphertext for each test case, one per line.

Sample Input
2
SPORT
LDXTW KXDTL NBSFX BFOII LNBHG ODDWN BWK
SECRET
JHQSU XFXBQ

Sample Output
ILOVE SOLVI NGPRO GRAMM INGCH ALLEN GES
CRYPT OLOGY
*/

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
