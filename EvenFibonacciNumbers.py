# Language : python 2
# project euler #2
# Sum all even values within the fibonacci sequence whose values do not exceed the given numer "N".

# Get the number of test cases : "T"
num = raw_input()

for x in range(0, int(num)):

    # Read in the max fib number for this test case : "N"
    fibNum = int(raw_input())
    a = 1
    b = 2
    l = []
    l.append(b)
    c = a + b
    
    while c < fibNum:
        
        if (c % 2 == 0):
            l.append(c)        
        a, b = b, c
        c = a + b
        
    print(sum(l))
