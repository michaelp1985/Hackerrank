"""
Do you believe in ghosts? Citizens of Byteland do. They want to estimate the population size of ghosts in their country.
There are A towns in Byteland. Every town consists of B streets. Each street has C houses. Finally, there are D apartments 
in each house. All the towns, streets, houses and apartments are numbered starting from 1. So, every 
apartment has a corresponding address described by 4 numbers.

A ghost lives in a particular apartment only if all the conditions below are true:
The difference between the town number and the street number is divisible by 3.
The sum of the street number and the house number is divisible by 5.
The product of the town number and the house number is divisible by 4.
The greatest common divisor of the town number and the apartment number is 1.
You are given the numbers A, B, C, and D.How many ghosts live in Byteland?

Input Format
The first line contains 4 space-separated integers: A, B, C, D.

Constraints
1 <= A, B, C, D <= 60

Output Format
Output the answer to the problem on the first line.

Sample Input
4 4 4 4

Sample Output
8

Explanation
Here are the addresses of all the ghosts:
1 1 4 1
1 1 4 2
1 1 4 3
1 1 4 4
4 1 4 1
4 1 4 3
4 4 1 1
4 4 1 3
"""

#!/bin/python3

import sys
from fractions import gcd


A,B,C,D = input().strip().split(' ')
A,B,C,D = [int(A)+1,int(B)+1,int(C)+1,int(D)+1]
ghost = 0

for a in range(1, A):
    for b in range(1, B):
        if ((a - b) % 3 == 0):
            for c in range(1, C):
                if (((b + c) % 5 == 0) & ((a * c) % 4 == 0)):
                    for d in range(1, D):
                        if (gcd(a,d) == 1):                            
                            ghost+=1

print(ghost)
