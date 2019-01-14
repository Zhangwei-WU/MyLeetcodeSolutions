
namespace LeetCode.P16
{
    using System;

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            int abs = int.MaxValue, result = 0;

            for (int i = 0, len = nums.Length; i < len - 2; i++)
            {
                var ni = target - nums[i];

                for (var j = i + 1; j < len; j++)
                {
                    var nj = ni - nums[j];
                    bool breakj = false;
                    for (var k = j + 1; k < len; k++)
                    {
                        var r = nj - nums[k];
                        if (r == 0) return target;
                        else if (r < 0)
                        {
                            if (-r < abs)
                            {
                                abs = -r;
                                result = target - r;
                                breakj = true;
                                break;
                            }
                        }
                        else
                        {
                            if (r < abs)
                            {
                                abs = r;
                                result = target - r;
                            }
                        }
                    }

                    if (breakj) break;
                }
            }

            return result;
        }
    }
}
