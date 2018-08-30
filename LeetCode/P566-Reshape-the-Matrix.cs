namespace LeetCode.P566
{
    public class Solution
    {
        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            var or = nums.GetLength(0);
            var oc = nums.GetLength(1);

            if (or * oc != r * c) return nums;
            if (or == r) return nums;

            var result = new int[r, c];
            int ri = 0, rj = 0;

            for (var i = 0; i < or; i++)
            {
                for (var j = 0; j < oc; j++)
                {
                    result[ri, rj++] = nums[i, j];
                    if (rj == c)
                    {
                        ri++;
                        rj = 0;
                    }
                }
            }

            return result;
        }
    }
}
