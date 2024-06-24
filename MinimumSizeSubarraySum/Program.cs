// See https://aka.ms/new-console-template for more information

var result = MinSubArrayLen(213, new[] { 12,28,83,4,25,26,25,2,25,25,25,12 });

Console.WriteLine(result);

int MinSubArrayLen(int target, int[] nums)
{
    var windowSize = 1;

    while(windowSize <= nums.Length) {
        for(int i = 0; i + windowSize - 1 < nums.Length; i++) {
            var windowValue = nums[i];

            if(windowSize > 1) {
                for(int j = 1 ; j <= windowSize - 1; j++) {
                    windowValue += nums[i + j];
                }
            }

            if(windowValue >= target) {
                return windowSize;
            }
        }

        windowSize++;
    }

    return 0;
}

int MinSubArrayLenChatGpt(int target, int[] nums)
{
    int minLength = int.MaxValue;
    int windowSum = 0;
    int left = 0;

    for (int right = 0; right < nums.Length; right++) {
        windowSum += nums[right];

        while (windowSum >= target) {
            minLength = Math.Min(minLength, right - left + 1);
            windowSum -= nums[left];
            left++;
        }
    }

    // If minLength is still int.MaxValue, it means no valid subarray found
    return minLength == int.MaxValue ? 0 : minLength;
}
