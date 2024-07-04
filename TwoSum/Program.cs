//Problem link: https://leetcode.com/problems/two-sum/description/?envType=study-plan-v2&envId=top-interview-150

var result = TwoSum([3,2,4], 6);
Console.WriteLine(string.Join(", ", result));

int[] TwoSum(int[] nums, int target)
{
    var numberAndWonderNumberDict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (!numberAndWonderNumberDict.TryAdd(nums[i], 1))
        {
            numberAndWonderNumberDict[nums[i]]++;
        }

        if (numberAndWonderNumberDict.ContainsKey(target-nums[i]) && numberAndWonderNumberDict.Keys.Count >= 2 && nums[i] * 2 != target)
        {
            return [i, nums.ToList().FindIndex(c => c == target - nums[i])];
        }

        if (numberAndWonderNumberDict.Any(p => p.Key * 2 == target && p.Value >=2))
        {
            return
            [
                nums.ToList().FindIndex(c => c == target - nums[i]),
                nums.ToList().FindLastIndex(c => c == target - nums[i])
            ];
        }
    }
    
    return new[] {1,2};
} 