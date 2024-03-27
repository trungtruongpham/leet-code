// Problem link: https://leetcode.com/problems/integer-to-roman/description/?envType=study-plan-v2&envId=top-interview-150

using System.Text;

var result = IntToRoman(40);
Console.WriteLine(result);

return;

// My solution, a tricky way it loops through dict and ignore value start with 5 and check only values start with 1
// Time complexity: O(1)
string IntToRoman(int num)
{
    var intToRoman = "";
    var dict = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    foreach (var element in dict.Reverse())
    {
        if (num == 0)
        {
            return intToRoman;
        }
        
        // Value smaller than current character value
        var byPassValues = new List<int> { 5, 50, 500 };
        if (num / element.Value == 0 || byPassValues.Contains(element.Value))
        {
            continue;
        }

        switch (num / element.Value)
        {
            case <= 3:
            {
                for (var i = 0; i < num / element.Value; i++)
                {
                    intToRoman += element.Key;
                }

                num -= (num / element.Value) * element.Value;
                break;
            }
            case 4:
                intToRoman += element.Key + dict.FirstOrDefault(k => k.Value == element.Value * 5).Key.ToString();
                num -= (num / element.Value) * element.Value;
                break;
            case 5:
                intToRoman += dict.FirstOrDefault(k => k.Value == element.Value * 5).Key;
                num -= element.Value * 5;
                break;
            case <= 8:
            {
                intToRoman += dict.FirstOrDefault(k => k.Value == element.Value * 5).Key;
                for (var i = 0; i < num / element.Value - 5; i++)
                {
                    intToRoman += element.Key;
                }
                num -= (num / element.Value) * element.Value;
                break;
            }
            default:
                intToRoman += element.Key + dict.FirstOrDefault(k => k.Value == element.Value * 10).Key.ToString();
                num -= 9 * element.Value;
                break;
        }
    }
    
    return intToRoman;
}

// Chat gpt solution with time complexity is O(1)
// Using string builder to append each character to result
string IntToRomanChatGpt(int num)
{
    if (num is <= 0 or > 3999)
        throw new ArgumentException("Input must be between 1 and 3999.");

    var intToRoman = new StringBuilder();
    int[] values = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
    string[] symbols = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];

    for (var i = 0; i < values.Length; i++)
    {
        while (num >= values[i])
        {
            num -= values[i];
            intToRoman.Append(symbols[i]);
        }
    }

    return intToRoman.ToString();
}