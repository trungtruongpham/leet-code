// Problem link: https://leetcode.com/problems/roman-to-integer/description/?envType=study-plan-v2&envId=top-interview-150

var result = RomanToInt("MCMXCIV");
Console.WriteLine(result);

return;

// My solution, convert string to char array and loop through array. Add value for each character, if it is special cases: minus double value
// Time complexity: O(N)
int RomanToInt(string s)
{
    var dict = new Dictionary<string, int>
    {
        {"I", 1},
        {"V", 5},
        {"X", 10},
        {"L", 50},
        {"C", 100},
        {"D", 500},
        {"M", 1000}
    };
    var romanToInt = 0;
    var arrRomanCharacters = s.ToCharArray();

    for (var i = 0; i < arrRomanCharacters.Length; i++)
    {
        var currentValue = arrRomanCharacters[i].ToString();
        dict.TryGetValue(currentValue, out var value);

        if (i >= 1)
        {
            if ((currentValue.Equals("V") || currentValue.Equals("X")) && arrRomanCharacters[i - 1].ToString().Equals("I"))
            {
                romanToInt += value - 2;
                continue;
            }
        
            if ((currentValue.Equals("L") || currentValue.Equals("C")) && arrRomanCharacters[i - 1].ToString().Equals("X"))
            {
                romanToInt += value - 20;
                continue;
            }
        
            if ((currentValue.Equals("D") || currentValue.Equals("M")) && arrRomanCharacters[i - 1].ToString().Equals("C"))
            {
                romanToInt += value - 200;
                continue;
            }
        }
        
        romanToInt += value;
    }

    return romanToInt;
}

// Chat gpt solution with time complexity is O(N)
// It removes ToString() method and access value of dictionary directly
// Loop through array from last element and check value of each element to decide we will minus or add to result
int RomanToIntChatGpt(string s)
{
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
    var romanToInt = 0;
    var arrRomanCharacters = s.ToCharArray();
    var prevValue = 0;

    for (var i = arrRomanCharacters.Length - 1; i >= 0; i--)
    {
        var currentValue = dict[arrRomanCharacters[i]];
        if (currentValue < prevValue)
        {
            romanToInt -= currentValue;
        }
        else
        {
            romanToInt += currentValue;
        }
        prevValue = currentValue;
    }

    return romanToInt;

}