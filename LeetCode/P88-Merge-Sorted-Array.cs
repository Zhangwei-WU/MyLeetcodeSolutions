namespace LeetCode.P88
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (var x = m - 1; x >= 0; x--) nums1[x + n] = nums1[x];
            var i = 0; var j = 0;
            var ci = i == m ? int.MaxValue : nums1[i + n];
            var cj = j == n ? int.MaxValue : nums2[j];
            var k = 0;
            while (i != m || j != n)
            {
                if (ci < cj) { nums1[k++] = ci; i++; ci = i == m ? int.MaxValue : nums1[i + n]; }
                else { nums1[k++] = cj; j++; cj = j == n ? int.MaxValue : nums2[j]; }
            }
        }
    }
}
