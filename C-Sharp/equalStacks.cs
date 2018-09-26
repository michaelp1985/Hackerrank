/*
You have three stacks of cylinders where each cylinder has the same diameter, but they may vary in height. 
You can change the height of a stack by removing and discarding its topmost cylinder any number of times.

Find the maximum possible height of the stacks such that all of the stacks are exactly the same height. 
This means you must remove zero or more cylinders from the top of zero or more of the three stacks until they're all the same height, 
then print the height. The removals must be performed in such a way as to maximize the height.

Note: An empty stack is still a stack.

Input Format

The first line contains three space-separated integers, N1, N2, and N3, describing the respective number of cylinders in 
stacks 1, 2, and 3. The subsequent lines describe the respective heights of each cylinder in a stack from top to bottom:

The second line contains N1 space-separated integers describing the cylinder heights in stack 1. The first element is the top of the stack.
The third line contains N2 space-separated integers describing the cylinder heights in stack 2. The first element is the top of the stack.
The fourth line contains N3 space-separated integers describing the cylinder heights in stack 3. The first element is the top of the stack.

Constraints
0 < N1, N2, N3 <= 10^5
0 < height of any cylinder <= 100

Output Format

Print a single integer denoting the maximum height at which all stacks will be of equal height.

Sample Input
5 3 4
3 2 1 1 1
4 3 2
1 1 4 1

Sample Output
5

*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        Console.ReadLine();
        string[] h1_temp = Console.ReadLine().Split(' ');
        int[] h1 = Array.ConvertAll(h1_temp,Int32.Parse);
        string[] h2_temp = Console.ReadLine().Split(' ');
        int[] h2 = Array.ConvertAll(h2_temp,Int32.Parse);
        string[] h3_temp = Console.ReadLine().Split(' ');
        int[] h3 = Array.ConvertAll(h3_temp,Int32.Parse);
        int h1Sum = h1.Sum();
        int h2Sum = h2.Sum();
        int h3Sum = h3.Sum();
        int h1i = 0, h2i = 0, h3i =0;
        
        while(h1Sum != h2Sum | h2Sum != h3Sum){
                                    
            if (h1Sum > h2Sum){
                if (h1Sum > h3Sum){
                    h1Sum -= h1[h1i++];                           
                }
                else{
                    h3Sum -= h3[h3i++];                    
                }
            }
            else{
                if (h2Sum > h3Sum){
                    h2Sum -= h2[h2i++];                    
                }
                else{
                    h3Sum -= h3[h3i++];                    
                }
            }
        }
        
        Console.WriteLine(h1Sum);
    }
}
