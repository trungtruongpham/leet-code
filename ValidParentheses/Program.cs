// Problem link: https://leetcode.com/problems/valid-parentheses/description/?envType=study-plan-v2&envId=top-interview-150

var result = IsValid("(){}}{");
Console.WriteLine(result);

//My solution: Create a stack, with character is open bracket I will push to stack otherwise I will pop and check it is valid or not
// Time complexity: O(N)
// Space complexity: O(N)

bool IsValid(string s)
{
    if (s.Length <= 1 || ")}]".Contains(s[0]))
    {
        return false;
    }

    var stack = new Stack<char>();

    foreach (var t in s)
    {
        if ("([{".Contains(t))
        {
            stack.Push(t);
        }
        else
        {
            if (stack.Count == 0 || !IsValidBracketPair(stack.Pop(), t))
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

bool IsValidBracketPair(char open, char close)
{
    if (!"([{".Contains(open)) return false;

    switch (open)
    {
        case '(':
            if (close.Equals(')'))
            {
                return true;
            }

            break;
        case '[':
            if (close.Equals(']'))
            {
                return true;
            }

            break;
        case '{':
            if (close.Equals('}'))
            {
                return true;
            }

            break;
        default:
            return false;
    }

    return false;
}