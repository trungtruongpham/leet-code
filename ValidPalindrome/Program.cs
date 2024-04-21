// Problem link: https://leetcode.com/problems/valid-palindrome/?envType=study-plan-v2&envId=top-interview-150

var result = IsPalindrome("A man, a plan, a canal: Panama");
Console.WriteLine(result);

// My solution: convert string to array with only alphabet character and use 2 pointers to check if string is valid palindrome
// Time complexity: O(N)
bool IsPalindrome(string s)
{
    var alphabetOnlyChars = Array.FindAll(s.ToLower().ToCharArray(), char.IsLetterOrDigit);
    var i = 0;
    var j = alphabetOnlyChars.Length - 1;
    while (i < j)
    {
        if (!alphabetOnlyChars[i].Equals(alphabetOnlyChars[j]))
        {
            return false;
        }

        i++;
        j--;
    }
    
    return true;
}

// ChatGpt: It reduce the variable to save memory and improve the readability of code
// Time complexity: O(N)
bool IsPalindromeChatGpt(string s)
{
    s = s.ToLower(); // Convert the string to lowercase for case insensitivity
    int i = 0, j = s.Length - 1;
    
    while (i < j)
    {
        // Move i to the next alphanumeric character
        while (i < j && !char.IsLetterOrDigit(s[i]))
            i++;
        
        // Move j to the previous alphanumeric character
        while (i < j && !char.IsLetterOrDigit(s[j]))
            j--;
        
        // Compare characters at i and j, ignoring case
        if (s[i] != s[j])
            return false;
        
        i++;
        j--;
    }
    
    return true;
}