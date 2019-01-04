namespace LeetCode.P121
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var len = prices.Length;
            if (len <= 1) return 0;

            var lowest = new int[len];
            var highest = new int[len];
            lowest[0] = prices[0];
            highest[len - 1] = prices[len - 1];
            for (var i = 1; i < len; i++)
            {
                var prev = lowest[i - 1];
                var curr = prices[i];
                lowest[i] = prev < curr ? prev : curr;
                prev = highest[len - i];
                curr = prices[len - 1 - i];
                highest[len - i - 1] = prev > curr ? prev : curr;
            }

            var max = 0;
            for (var i = 0; i < len; i++)
            {
                var profit = highest[i] - lowest[i];
                if (profit > max) max = profit;
            }

            return max;
        }
    }
}
