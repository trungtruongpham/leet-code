// Problem link: https://leetcode.com/problems/contains-duplicate-ii/?envType=study-plan-v2&envId=top-interview-150

var result = ContainsNearbyDuplicate([1,2,3,1], 3);
Console.WriteLine(result);

bool ContainsNearbyDuplicate(int[] nums, int k)
{
    var dict = new Dictionary<int, int>();
    
    for (var i = 0; i < nums.Length; i++)
    {
        if (!dict.TryAdd(nums[i], i) && Math.Abs(dict[nums[i]] - i) <= k)
        {
            return true;
        }

        if (dict.ContainsKey(nums[i]))
        {
            dict[nums[i]] = i;
        }
    }
    
    return false;
}