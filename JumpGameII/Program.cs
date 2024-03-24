// Problem link: https://leetcode.com/problems/jump-game-ii/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [9,8,2,2,0,2,2,0,4,1,5,7,9,6,6,0,6,5,0,5];
var result = JumpGameII(testValue);
Console.WriteLine(result);

return;

// My solution, loop all possible place in array. This solution is O(N^2) time complexity
int JumpGameII(int[] nums)
{
    if(nums.Length == 1) return 0;
    var steps = 0;
    var i = 0;

    while(i < nums.Length)
    {
        steps++;
        
        //If in maxJump position we are able to jump to last index
        if (nums[i] + i >= nums.Length - 1)
        {
            return steps;
        }
        
        //Find maxJump and maxJumpPosition which has high chance to jump to last index
        var maxJump = 0;
        var maxJumpPosition = i + 1;
        for (var j = i + 1; j <= i + nums[i]; j++)
        {
            if (j + nums[j] >= nums.Length - 1)
            {
                return steps+1;
            }
            
            //Ensure that maxJumpPosition will reach the furthest position
            if (nums[j] + j < maxJump + maxJumpPosition)
            {
                continue;
            }
            
            maxJump = nums[j];
            maxJumpPosition = j;
        }
        
        if (maxJumpPosition < nums.Length - 1)
        {
            i = maxJumpPosition;
        }
    }

    return steps;
}

// Chat gpt solution with time complexity is O(N)
int JumpGameChatGpt(int[] nums)
{
    if (nums.Length == 1) return 0;
    
    var steps = 0;
    var currentJumpEnd = 0;
    var farthest = 0;

    for (var i = 0; i < nums.Length - 1; i++) {
        farthest = Math.Max(farthest, i + nums[i]);
        
        if (i == currentJumpEnd) {
            steps++;
            currentJumpEnd = farthest;
        }
    }

    return steps;
}