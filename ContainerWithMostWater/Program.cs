// Problem link: https://leetcode.com/problems/valid-palindrome/?envType=study-plan-v2&envId=top-interview-150

var result = MaxArea([2,3,4,5,18,17,6]);
Console.WriteLine(result);

int MaxArea(int[] height)
{
    if (height.Length == 2)
    {
        return Math.Min(height[0], height[1]);
    }
    
    var maxArea = 0;
    for (var i = 0; i < height.Length; i++)
    {
        if(height[i] == 0) {
            continue;
        }
        
        for (int j = i+1; j < height.Length; j++)
        {
            var currentArea = Math.Min(height[i], height[j]) * (j - i);
            maxArea = Math.Max(maxArea, currentArea);
        }
    }

    return maxArea;
}