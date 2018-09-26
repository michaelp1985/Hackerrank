/*
You are given an integer, N. Write a program to determine if N is an element of the Fibonacci sequence.

The first few elements of the Fibonacci sequence are 0, 1, 1, 3, 5, 8, 13. A Fibonacci sequence is one where every element is a 
sum of the previous two elements in the sequence. The first two elements are 0 and 1.

Input Format 
The first line contains T, number of test cases. 
T lines follow. Each line contains an integer N.

Output Format 
Display IsFibo if N is a Fibonacci number and IsNotFibo if it is not. The output for each test case should be displayed in a new line.

Constraints 

1 <= T <= 10^5
1 <= N <= 10^10

Sample Input

3
5
7
8

Sample Output

IsFibo
IsNotFibo
IsFibo

Explanation 
5 is a Fibonacci number given by fib5 = 3 + 2
7 is not a Fibonacci number 
8 is a Fibonacci number given by fib6 = 5 + 3

Time Limit 
Time limit for this challenge is given here -> https://www.hackerrank.com/environment. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        
        int cases = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < cases; i++)
            {                       
            
            long fib = Convert.ToInt64(Console.ReadLine());
            
            if (fib == 1)
                Console.WriteLine("IsFibo");            
            else if(isFibo(1, 1, fib))
                {
                Console.WriteLine("IsFibo");
            }
            else
                {
                Console.WriteLine("IsNotFibo");
            }
        }
    }
    
    public static bool isFibo(long a, long b, long c)
        {
        long val = a + b;
        
        if (val == c)
            return true;
        else if (val > c)
            return false;
        else
            return (isFibo(b, val, c));
            
    }
}
