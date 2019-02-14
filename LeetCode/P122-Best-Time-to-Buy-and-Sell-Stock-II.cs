

namespace LeetCode.P122
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0, i = 0, length = prices.Length;
            while (i < length)
            {
                while (i < length - 1 && prices[i] >= prices[i + 1]) ++i;
                if (i == length - 1) break;

                var low = prices[i++];
                while (i < length - 1 && prices[i] <= prices[i + 1]) ++i;
                profit += prices[i] - low;
            }

            return profit;
        }
    }
}
