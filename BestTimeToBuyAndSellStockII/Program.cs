// Problem link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [1,2,3,4,5];
var result = MaxProfit(testValue);

Console.WriteLine(result);

return;

// Original solution with time complexity is O(n^2) and fail some test cases
// This solution will fail when test cases with a lot of numbers in list.
int MaxProfit(int[] prices)
{
    var maxProfit = 0;

    for(var i = 1 ; i < prices.Length; i++)
    {
        if (prices[i] > prices[i - 1])
        {
            maxProfit += prices[i] - prices[i - 1];
        }
    }

    return maxProfit == 0 ? 0 : maxProfit;
}


// Optimized solution from ChatGPT, using Math.Max to reduce if statement
int MaxProfitChatGpt(int[] prices) {
    var maxProfit = 0;

    for(var i = 1 ; i < prices.Length; i++) {
        maxProfit += Math.Max(0, prices[i] - prices[i - 1]);
    }

    return maxProfit;
}