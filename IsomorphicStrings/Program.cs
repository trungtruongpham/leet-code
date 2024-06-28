// See https://aka.ms/new-console-template for more information

// Problem link: https://leetcode.com/problems/isomorphic-strings/?envType=study-plan-v2&envId=top-interview-150

var result = IsIsomorphic("badc", "baba");
Console.WriteLine(result);

// My solution: Apply reduce for in last hasmap problem to improve performance
// Time complexity: O(N)
// Space complexity: O(N)

bool IsIsomorphic(string s, string t)
{
    // Early return when length of 2 strings are not match
    if (s.Length != t.Length)
    {
        return false;
    }

    var mappingDict = new Dictionary<char, char>();
    
    for (int i = 0; i < s.Length; i++)
    {
        if ((mappingDict.ContainsKey(s[i]) && !mappingDict[s[i]].Equals(t[i])) 
            || (!mappingDict.ContainsKey(s[i]) && mappingDict.ContainsValue(t[i])))
        {
            return false;
        }
        
        mappingDict.TryAdd(s[i], t[i]);
    }
    
    return true;
}