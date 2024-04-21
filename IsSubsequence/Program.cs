// Problem link: https://leetcode.com/problems/is-subsequence/description/?envType=study-plan-v2&envId=top-interview-150

using System.Reflection.Metadata.Ecma335;

var result = IsSubsequence("ab", "baab");
Console.WriteLine(result);

// My solution: Use 2 pointers for checking through 2 string.
// Time complexity: O(N) N - T.Length
bool IsSubsequence(string s, string t)
{
    if (string.IsNullOrEmpty(s))
    {
        return true;
    }
    
    var charArrayOfS = s.ToCharArray();
    var charArrayOfT = t.ToList();

    var i = 0;
    var lastFindIndex = 0;
    for (var j = 0; j < charArrayOfT.Count; j++)
    {
        if (i == charArrayOfS.Length)
        {
            return true;
        }

        if (!charArrayOfS[i].Equals(charArrayOfT[j]) || j < lastFindIndex)
        {
            continue;
        }
        
        i++;
        lastFindIndex = j;
    }
    
    return i == charArrayOfS.Length;
}


// ChatGpt: Same logic but code is cleaner. It uses only 2 variables and don't need to convert string to char array.
// Time Complexity: O(n)
bool IsSubsequenceChatGpt(string s, string t)
{
    if (string.IsNullOrEmpty(s))
    {
        return true;
    }

    int i = 0, j = 0;
    while (j < t.Length)
    {
        if (s[i] == t[j])
        {
            i++;
            if (i == s.Length)
            {
                return true;
            }
        }
        j++;
    }
    return false;
}