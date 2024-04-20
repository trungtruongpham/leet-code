// Problem link: https://leetcode.com/problems/longest-common-prefix/?envType=study-plan-v2&envId=top-interview-150

var result = LongestCommonPrefix(["flower","flower","flower","flower"]);

Console.WriteLine(result);

// My solution: Loop through each character of first word and add to a variable. After that check if prefix variables is valid
// Time complexity: O(n*m) n = length of largest string, m = length of list string
string LongestCommonPrefix(string[] strs)
{
        if (strs.Length == 1)
        {
                return strs.FirstOrDefault() ?? string.Empty;
        }

        var firstWord = strs.FirstOrDefault();

        if (firstWord is null)
        {
                return string.Empty;
        }

        var listCharFromFirstWord = firstWord.ToCharArray();
        var longestCommonPrefix = string.Empty;

        foreach (var c in listCharFromFirstWord)
        {
                var prefix = longestCommonPrefix + c;
                if(!strs.ToList().All(s => s.StartsWith(prefix)))
                {
                        return longestCommonPrefix;
                }

                longestCommonPrefix += c;
        }
        
        return longestCommonPrefix;
}


// Chat gpt solution: Find shortest word in string list and use binary search to find longest common prefix
// Time complexity: O(m * (log n + n))
string LongestCommonPrefixChatGpt(string[] strs)
{
        if (strs == null || strs.Length == 0)
                return "";

        // Find the shortest string in the array
        string shortest = strs[0];
        foreach (string str in strs)
        {
                if (str.Length < shortest.Length)
                        shortest = str;
        }

        // Binary search for the longest common prefix
        int low = 1;
        int high = shortest.Length;
        while (low <= high)
        {
                int mid = (low + high) / 2;
                if (IsCommonPrefix(strs, shortest.Substring(0, mid)))
                        low = mid + 1;
                else
                        high = mid - 1;
        }

        return shortest.Substring(0, (low + high) / 2);
}

bool IsCommonPrefix(string[] strs, string prefix)
{
        foreach (string str in strs)
        {
                if (!str.StartsWith(prefix))
                        return false;
        }
        return true;
}