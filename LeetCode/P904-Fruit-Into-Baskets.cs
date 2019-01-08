namespace LeetCode.P904
{
    public class Solution
    {
        public int TotalFruit(int[] tree)
        {
            var len = tree.Length;
            if (len <= 2) return len;

            var cnt = new int[len];
            var rlen = 0;
            for (int i = 0, prev = tree[0], curr; i < len; i++)
            {
                if ((curr = tree[i]) == prev)
                {
                    cnt[rlen]++;
                    continue;
                }

                prev = curr;
                tree[++rlen] = curr;
                cnt[rlen] = 1;
            }

            rlen++; // total grouped
            var total = cnt[0];
            if (rlen == 1) return total;

            var subtotal = total + cnt[1];
            for (int i = 2; i < rlen; i++)
            {
                if (tree[i - 2] == tree[i])
                {
                    subtotal += cnt[i];
                    continue;
                }

                if (subtotal > total) total = subtotal;
                subtotal = cnt[i - 1] + cnt[i];
            }

            return subtotal > total ? subtotal : total;
        }
    }
}
