# Week of code 18, challenge 2, 11.2015

#!/bin/python3

import sys
import math

K,N = input().strip().split(' ')
K,N = [int(K),int(N)]
R = [int(R_temp) for R_temp in input().strip().split(' ')]
x = []
for x_i in range(N):
   x_t = [int(x_temp) for x_temp in input().strip().split(' ')]
   x.append(x_t)

rings = list()
rings.append(0)
    
if (K > 1):
    for r in range(0, K):    
        rings.append(R[K-1-r])
else:
   rings.append(R[0])

final = 0
darts = []

for f in range(N):
    darts.append(math.sqrt(math.fabs(math.pow(x[f][0],2)) + math.fabs(math.pow(x[f][1],2))))
    
for d in range(N):
    next = False
    for r in range(K+1):        
        if (next):
            break
        
        if (darts[d] < R[0]): 
            if (darts[d] <= rings[r]):
                if (r == 0):
                    final += K
                else:                    
                    final += K - int(math.fabs(r-1))
                next = True
        else:
            next = True
    
print(final)
