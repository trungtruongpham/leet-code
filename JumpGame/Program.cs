// Problem link: https://leetcode.com/problems/jump-game/description/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [4,1,0,2,2,4,4,4,1,2];
var result = JumpGame(testValue);
Console.WriteLine(result);

return;

// From NeetCode, he traces back from the goal to find the possible index. This solution is O(N) time complexity
bool JumpGameGreedy(int[] nums)
{
    var goal = nums.Length - 1;
    for (var i = nums.Length - 2; i >= 0; i--)
    {
        if (nums[i] + i >= goal)
        {
            goal = i;
        }
    }

    return goal == 0 ? true : false;
}

// My solution, loop all possible place in array. This solution is O(N^N) time complexity
bool JumpGame(int[] nums)
{
    if (nums.Length == 1) return true;
    if (nums[0] == 0 && nums.Length > 1) return false;

    for (var i = 0; i < nums.Length - 1; i++)
    {
        if (nums[i] == 0) continue;
        if (nums[i] + i >= nums.Length - 1) return true;

        var nextJumpPossible = false;

        for (var j = i + 1; j <= i + nums[i]; j++)
        {
            if(nums[j] == 0 ) continue;
            
            nextJumpPossible = true;

            if (j + nums[j] >= nums.Length - 1)
            {
                return true;
            }
        }

        if (!nextJumpPossible)
        {
            return false;
        }
    }

    return false;
}

// Chat gpt solution with time complexity is O(N)
bool JumpGameChatGpt(int[] nums)
{
    int maxReach = 0;
    int n = nums.Length;

    for (int i = 0; i < n; i++)
    {
        if (i > maxReach) // If current index is not reachable
            return false;

        maxReach = Math.Max(maxReach, i + nums[i]); // Update max reachable index

        if (maxReach >= n - 1) // If we can reach the end
            return true;
    }

    return false;
}