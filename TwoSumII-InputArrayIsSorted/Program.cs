// Problem link: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/?envType=study-plan-v2&envId=top-interview-150

var result = TwoSum([5,25,75], 100);
Console.WriteLine(result[0] + " " + result[1]);

// My solution: It is an increasing array so I use 2 pointers: 1 from start, 1 from finish
// Compare sum of 2 values of element in pointers position with target to decide we will move what pointer
// Time complexity: O(N)
int[] TwoSum(int[] numbers, int target)
{
    if (numbers.Length < 3)
    {
        return [1, 2];
    }

    var i = 0;
    var j = numbers.Length - 1;

    while (i < j)
    {
        if (numbers[i] + numbers[j] == target)
        {
            return [i + 1, j + 1];
        }

        if (numbers[i] + numbers[j] > target)
        {
            j--;
        }
        else
        {
            i++;
        }
    }

    return [1,2];
}

// ChatGpt: Same approach with my solution but it has some optimizations.
// Time complexity: O(N)
int[] TwoSumChatGpt(int[] numbers, int target)
{
    int i = 0;
    int j = numbers.Length - 1;

    while (i < j)
    {
        int sum = numbers[i] + numbers[j];
        if (sum == target)
        {
            return new int[] { i + 1, j + 1 };
        }
        else if (sum > target)
        {
            j--;
        }
        else
        {
            i++;
        }
    }

    return new int[] { -1, -1 }; // Indicate no solution found
}