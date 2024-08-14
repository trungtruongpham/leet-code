// See https://aka.ms/new-console-template for more information
var result = SearchInsert([1,3], 2);

Console.WriteLine(result);

int SearchInsert(int[] nums, int target)
{
        if(nums[0] > target) {
                return 0;
        }

        if(nums.Length == 1 ) {
                return nums[0] >= target ? 0 : 1;
        }

        var left = 0;
        var right = nums.Length - 1;
        var middle = (left + right) / 2;

        while (left <= right)
        {
                if (nums[middle] == target)
                {
                        return middle;
                }
                
                if (nums[middle] > target)
                {
                        right = middle - 1;
                        middle = (left + right) / 2;
                }
                else
                {
                        left = middle + 1;
                        middle = (left + right) / 2;
                }
        }
        
        return nums[middle] > target ? middle : middle + 1;
}