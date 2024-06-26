// See https://aka.ms/new-console-template for more information

// Question Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/?envType=study-plan-v2&envId=top-interview-150

var result = LengthOfLongestSubString("aa");
Console.WriteLine(result);

// My Solution: Use 2 loops to ensure get all combinations of characters in string
// Time complexity: O(N^2)
// My first submit using Dict.Keys.Any() this method will make time complexity to O(N^3) -> change to use Dict.ContainsKey()

int LengthOfLongestSubString(string s)
{
    if (s.Length == 1)
    {
        return 1;
    }

    var charactersDict = new Dictionary<char, int>();
    var lengthOfNonRepeatString = 0;

    for (int left = 0; left < s.Length; left++)
    {
        for(var right = left; right < s.Length; right++)
        {
            if (charactersDict.ContainsKey(s[right]))
            {
                if (charactersDict.Keys.Count > lengthOfNonRepeatString)
                {
                    lengthOfNonRepeatString = charactersDict.Keys.Count;
                }

                charactersDict = new Dictionary<char, int>();
                break;
            }

            charactersDict.Add(s[right], 1);
        }
    }

    return lengthOfNonRepeatString;
}


//Chat gpt solution: It reduces a loop by tracking last duplicate character
//Time complexity: 0(N)
int LengthOfLongestSubstringChatGpt(string s) {
    if (s.Length == 0) {
        return 0;
    }

    var charactersDict = new Dictionary<char, int>();
    int maxLength = 0;
    int left = 0;

    for (int right = 0; right < s.Length; right++) {
        if (charactersDict.ContainsKey(s[right])) {
            // Move the left pointer to the right of the last seen duplicate character
            left = Math.Max(charactersDict[s[right]] + 1, left);
        }

        // Update the last seen position of the character
        charactersDict[s[right]] = right;
        // Calculate the length of the current non-repeating substring
        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}