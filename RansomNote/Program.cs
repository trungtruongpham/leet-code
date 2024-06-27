// Problem link: https://leetcode.com/problems/game-of-life/?envType=study-plan-v2&envId=top-interview-150

var result = CanConstruct("a", "b");
Console.WriteLine(result);

// My solution: Create 2 dicts and store all chars of 2 string to 2 dicts
// Check if value of ransomeNote dict is in magazineDict
// Time complexity: O(N+M)
// Space complexity: O(N+M)

bool CanConstruct(string ransomNote, string magazine)
{
    var ransomNoteDict = new Dictionary<char, int>();
    var magazineDict = new Dictionary<char, int>();

    foreach (var c in ransomNote)
    {
        if (!ransomNoteDict.TryAdd(c, 1))
        {
            ransomNoteDict[c]++;
        }
    }
    
    foreach (var c in magazine)
    {
        if (!magazineDict.TryAdd(c, 1))
        {
            magazineDict[c]++;
        }
    }

    foreach (var value in ransomNoteDict)
    {
        if (!magazineDict.TryGetValue(value.Key, out var magazineValue) || (magazineValue < value.Value))
        {
            return false;
        }
    }
    
    return true;
}

// Chatpt optimize: It reduce dict for ransomNote by comparing directly value with magazineDict
// With this solution Time Complexity is the same O(N+M) but it can reduce Space Complexity to O(N)
bool CanConstructChatGpt(string ransomNote, string magazine) {
    var magazineDict = new Dictionary<char, int>();

    foreach (var c in magazine) {
        if (!magazineDict.TryAdd(c, 1)) {
            magazineDict[c]++;
        }
    }

    foreach (var c in ransomNote) {
        if (!magazineDict.TryGetValue(c, out var count) || count == 0) {
            return false;
        }
        magazineDict[c]--;
    }

    return true;
}