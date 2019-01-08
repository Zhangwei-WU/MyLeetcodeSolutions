namespace LeetCode.P4
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length, len2 = nums2.Length;

            if (len1 < len2)
            {
                var l1 = len1; len1 = len2; len2 = l1;
                var n1 = nums1; nums1 = nums2; nums2 = n1;
            }

            for (int lo = 0, hi = len2 << 1; lo <= hi;)
            {
                int mid2 = (lo + hi) >> 1, mid1 = len1 + len2 - mid2;
                int
                    l1 = (mid1 == 0) ? int.MinValue : nums1[(mid1 - 1) >> 1],
                    l2 = (mid2 == 0) ? int.MinValue : nums2[(mid2 - 1) >> 1],
                    r1 = (mid1 == (len1 << 1)) ? int.MaxValue : nums1[mid1 >> 1],
                    r2 = (mid2 == (len2 << 1)) ? int.MaxValue : nums2[mid2 >> 1];

                if (l1 > r2) lo = mid2 + 1;
                else if (l2 > r1) hi = mid2 - 1;
                else return ((l1 > l2 ? l1 : l2) + (r1 < r2 ? r1 : r2)) / 2.0d;
            }

            return -1.0d;
        }
    }
}
