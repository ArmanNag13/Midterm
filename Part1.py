def ispolindrom(string):
    s = string.lower()
    
    
    
    start = 0
    end = len(s) - 1
    while start < end:
        if string[start] != string[end]:
            return False
        start += 1
        end -= 1
    return True



input = "Anna"
result = ispolindrom(input)
print(result)


