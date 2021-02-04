import math

def square(val):
    return math.pow(val,2)

def score(x, y):
    '''
    Give a score given X and Y co-ordinates
    Rules
    X range -10,10
    Y range -10, 10
    The problem is finding the radius of the circle created by a given point x,y
    then compare if the point is inside the circle using pythagoras theorem
    where a^2 + b^2 = c^2
    
    '''
    if (square(x) + square(y)) <= square(1):
        return 10
    elif ((square(x) + square(y)) <= square(5)) and ((square(x) + square(y)) > square(1)):
        return 5
    elif ((square(x) + square(y)) <= square(10)) and ((square(x) + square(y)) > square(5)):
        return 1
    else:
        return 0 

if __name__ == "__main__":
    result = score(0,10)
    print(result)
    assert result == 1