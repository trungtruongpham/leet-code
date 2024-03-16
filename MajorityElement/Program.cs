// Problem link: https://leetcode.com/problems/majority-element/description/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [3,2,3];
var result = MajorityElement(testValue);

return;

// My solution
int MajorityElement(int[] nums)
{
    var dict = new Dictionary<int, int>();

    foreach (var num in nums)
    {
        if (!dict.TryAdd(num, 1))
        {
            dict[num]++;
        }
    }

    return dict.FirstOrDefault(s => s.Value > nums.Length / 2).Key;
}

// Using Boyer-Moore Majority Vote Algorithm
int MajorityElementChatGpt(int[] nums)
{
    int candidate = 0;
    int count = 0;

    // Finding the majority candidate
    foreach (var num in nums)
    {
        if (count == 0)
        {
            candidate = num;
            count = 1;
        }
        else if (num == candidate)
        {
            count++;
        }
        else
        {
            count--;
        }
    }

    // Verifying if the candidate is the majority element
    count = 0;
    foreach (var num in nums)
    {
        if (num == candidate)
        {
            count++;
        }
    }

    // Checking if the candidate is indeed the majority element
    return count > nums.Length / 2 ? candidate : 0;
}