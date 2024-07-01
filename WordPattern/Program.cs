// See https://aka.ms/new-console-template for more information

var result = WordPattern("abba", "dog cat cat fish");
Console.WriteLine(result);

// My solution: I split string to list words and add with each character of pattern to a dictionary.
// After that I compare each key-value pair to ensure it is valid.
// Time complexity: O(n^2)
// Space complexity: O(m+n)

bool WordPattern(string pattern, string s)
{
    var listWords = s.Split(" ");
    if (pattern.Length != listWords.Length)
    {
        return false;
    }
    
    var patternAndWordDict = new Dictionary<char, string>();
    for(var i = 0; i < pattern.Length; i++) {
        if(patternAndWordDict.Any(k => !k.Value.Equals(listWords[i]) && k.Key.Equals(pattern[i])) 
           || patternAndWordDict.Any(k => k.Value.Equals(listWords[i]) && !k.Key.Equals(pattern[i]))) {
            return false;
        }

        if (!patternAndWordDict.ContainsKey(pattern[i]))
        {
            patternAndWordDict.Add(pattern[i], listWords[i]);
        }
    }

    return true;
}


//Chatgpt optimized solution
// It reduces Any method which has O(N) time complexity by ContainsKey method which has O(1) time complexity
// => When ever we use Any method with Dictionary we can replace this by ContainsKey or TryAdd to get better performance
// Time complexity: O(m+n)
// Space complexity: O(m+n)

bool WordPatternChatGpt(string pattern, string s) {
    var listWords = s.Split(" ");
    if (pattern.Length != listWords.Length) {
        return false;
    }

    var patternToWord = new Dictionary<char, string>();
    var wordToPattern = new Dictionary<string, char>();

    for (int i = 0; i < pattern.Length; i++) {
        char p = pattern[i];
        string word = listWords[i];

        if (patternToWord.ContainsKey(p)) {
            if (patternToWord[p] != word) {
                return false;
            }
        } else {
            patternToWord[p] = word;
        }

        if (wordToPattern.ContainsKey(word)) {
            if (wordToPattern[word] != p) {
                return false;
            }
        } else {
            wordToPattern[word] = p;
        }
    }
    return true;
}