// Problem link: https://leetcode.com/problems/valid-anagram/description/?envType=study-plan-v2&envId=top-interview-150

var result = IsAnagram("anagram", "nagarama");

Console.WriteLine(result);

// Time complexity: O(N+M)
// Space complexity: O(N)
bool IsAnagram(string s, string t)
{
    var dictCharsOfStringS = new Dictionary<char, int>();

    foreach (var s1 in s)
    {
        if (!dictCharsOfStringS.TryAdd(s1, 1))
        {
            dictCharsOfStringS[s1]++;
        }
    }

    foreach (var t1 in t)
    {
        // If dict chars of string S is not contains character from string T -> it will be invalid strings
        if (!dictCharsOfStringS.TryGetValue(t1, out int value))
        {
            return false;
        }

        dictCharsOfStringS[t1] = --value;
    }

    return dictCharsOfStringS.All(k => k.Value == 0);
}