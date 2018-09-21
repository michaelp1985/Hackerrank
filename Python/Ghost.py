"""

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
