
namespace LeetCode.P322
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            HashSet<int> distinctedCoins = new HashSet<int>();
            foreach (var coin in coins) if (coin > 0) distinctedCoins.Add(coin);
            var len = distinctedCoins.Count;
            coins = new int[len];
            distinctedCoins.CopyTo(coins);
            Array.Sort(coins, (a, b) => b - a);

            if (coins.Length == 0) return -1;
            return Take(coins, amount, 0, new int[amount + 1]);
        }
        
        private int Take(int[] coins, int amount, int depth, int[] records)
        {
            var ldepth = records[amount];
            if (ldepth == 0)
            {
                ldepth = -1;

                for (var i = 0; i < coins.Length; i++)
                {
                    var remain = amount - coins[i];
                    if (remain < 0) continue;
                    if (remain == 0) { ldepth = 1; break; }
                    var tdepth = Take(coins, remain, depth + 1, records);
                    if (tdepth == -1) continue;
                    tdepth -= depth;
                    if (ldepth == -1 || ldepth > tdepth) ldepth = tdepth;
                }

                records[amount] = ldepth;
            }

            return ldepth == -1 ? -1 : ldepth + depth;
        }
    }
}