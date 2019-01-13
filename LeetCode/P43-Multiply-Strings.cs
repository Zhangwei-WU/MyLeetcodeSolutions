namespace LeetCode.P43
{
    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            char[] c1 = num1.ToCharArray(), c2 = num2.ToCharArray();

            int l1 = c1.Length, l2 = c2.Length;
            int[] n1 = new int[l1], n2 = new int[l2];
            for (var i = 0; i < l1; i++) n1[l1 - i - 1] = c1[i] - '0';
            for (var i = 0; i < l2; i++) n2[l2 - i - 1] = c2[i] - '0';

            var result = new int[l1 + l2];
            for (var i = 0; i < l2; i++)
            {
                var digit = n2[i];
                if (digit == 0) continue;
                MultiplyAdd(n1, l1, digit, result, l1 + l2, i);
            }

            l2 += l1;
            var sb = new char[l2];
            var len = 0;
            for (var i = result[l2 - 1] == 0 ? l2 - 2 : l2 - 1; i >= 0; i--) sb[len++] = (char)(result[i] + '0');

            return new string(sb, 0, len);
        }

        private void MultiplyAdd(int[] n1, int length, int digit, int[] result, int rlength, int index)
        {
            for (int i = 0, x = 0; i <= length; i++)
            {
                if (i == length)
                {
                    var ri = result[index + i];
                    ri += x;
                    if (ri >= 10)
                    {
                        result[index + i] = ri - 10;
                        result[index + i + 1] += 1;
                    }
                    else
                    {
                        result[index + i] = ri;
                    }
                }
                else
                {
                    var c = n1[i] * digit + x + result[index + i];
                    x = c / 10;
                    result[index + i] = c - x * 10;
                }
            }
        }
    }
}
