// Problem link: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [0,0,1,1,1,1,2,3,3];
var result = RemoveDuplicates(testValue);

return;

int RemoveDuplicates(int[] nums)
{
    int i = 0;

    foreach (var num in nums)
    {
        if (i < 2 || num > nums[i - 2])
        {
            nums[i++] = num;
        }
    }

    return i;
}