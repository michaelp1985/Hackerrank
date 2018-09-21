# Week of code 18, challenge 2, 11.2015
#!/bin/python3

"""
Let's consider a standard darts target that consists of K concentric circles with the corresponding 
radiuses R1, R2,....Rk with the common center in the origin (0,0).
If your shot lands inside the smallest circle, you will get K points. Landing between the i'th and the (i + 1)th 
circle will give you i points. This means your shot includes the i'th circle, but excludes the (i+1)th circle. 
If the shot lands on the boundary of the circle, it will be considered to have landed inside that circle.

Finally, if you are unable to land inside or on the boundary of the 1st circle, you will get 0 points for that shot.
You are given coordinates x'i,y'i, of N shots. Calculate the final score (the sum of all the points).

Input Format
The first line contains two space-separated integers: K and N.
The second line contains K space-separated integers: R1, R2,...Rk.

The following N lines contain two-space separated integers x'i, y'i, the coordinates of the i'th shot.

Constraints
1 <= K <= 10^4
1 <= N <= 5 * 10^5
1 <= R'k < R'k-1 <...< R1 <= 5 * 10^4
|x'i|, |y'i| <= 5 * 10^4

In test data worth 40% of points, 1 <= N <= 10^3 holds in addition.

Output Format
Output one integer on a single line: The sum of all the points scored.

Sample Input
5 6
10 8 6 4 2
0 0
1 1
2 2
3 3
4 4
5 5

Sample Output
22

Explanation
The partial scores are: 5 + 5 + 4 + 3 + 3 + 2 = 22
"""

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
