
namespace LeetCode.P152
{
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            var max = int.MinValue;
            for (int i = 0, l = nums.Length, j; i < l;)
            {
                int negCount = 0, firstNegIndex = -1, lastNegIndex = -1;

                for (j = i; j <= l; ++j)
                {
                    if (j == l || nums[j] == 0)
                    {
                        if (j != l && max < 0) max = 0;
                        break;
                    }
                    else if (nums[j] < 0)
                    {
                        negCount++;
                        if (firstNegIndex == -1) firstNegIndex = j;
                        lastNegIndex = j;
                    }
                }

                if (j == i)
                {
                    if (max < 0) max = 0;
                }
                else if (negCount % 2 == 0)
                {
                    var cmax = 1;
                    for (var k = i; k < j; ++k) cmax *= nums[k];
                    if (cmax > max) max = cmax;
                }
                else if (negCount == 1)
                {
                    int left = int.MinValue, right = int.MinValue;

                    if (firstNegIndex != i)
                    {
                        left = 1;
                        for (var k = i; k < firstNegIndex; ++k) left *= nums[k];
                    }

                    if (firstNegIndex != j - 1)
                    {
                        right = 1;
                        for (var k = firstNegIndex + 1; k < j; ++k) right *= nums[k];
                    }

                    var cmax = left > right ? left : right;
                    if (cmax > max) max = cmax;
                    if (nums[firstNegIndex] > max) max = nums[firstNegIndex];
                }
                else
                {
                    int cmax = 1, left = 1, right = 1;
                    for (var k = firstNegIndex + 1; k < lastNegIndex; ++k) cmax *= nums[k];
                    for (var k = i; k <= firstNegIndex; ++k) left *= nums[k];
                    for (var k = lastNegIndex; k < j; ++k) right *= nums[k];
                    cmax *= (left < right ? left : right);

                    if (cmax > max) max = cmax;
                }

                i = j + 1;
            }

            return max;
        }
    }
}
