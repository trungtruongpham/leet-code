// Problem link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/?envType=study-plan-v2&envId=top-interview-150

int[] testValue = [7,1,5,3,6,4];
var result = MaxProfit(testValue);

return;

// Original solution with time complexity is O(n^2) and fail some test cases
// This solution will fail when test cases with a lot of numbers in list.
int MaxProfit(int[] prices)
{
    var maxProfit = 0;

    for(var i = 0 ; i < prices.Length; i++) {
        for(var j = prices.Length-1; j > i; j--) {
            if(prices[j] - prices[i] > maxProfit) {
                maxProfit = prices[j] - prices[i];
            }
        }
    }

    return maxProfit == 0 ? 0 : maxProfit;
}


// Optimized solution from ChatGPT, it use 1 variable to find min value and 1 variable to store maxProfit. By this way
// this solution can reduce time complexity to O(n) and pass all test cases
int MaxProfitChatGpt(int[]? prices) {
    if (prices == null || prices.Length < 2) {
        return 0; // If there are fewer than two prices, we cannot make any profit
    }

    var minPrice = prices[0]; // Initialize the minimum price to the first price
    var maxProfit = 0; // Initialize the maximum profit to zero

    for (var i = 1; i < prices.Length; i++) {
        // Update the minimum price if the current price is lower
        minPrice = Math.Min(minPrice, prices[i]);

        // Update the maximum profit if selling at the current price yields more profit
        maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
    }

    return maxProfit;
}