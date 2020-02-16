namespace LeetCode.P365
{

    public class Solution
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (z == 0) return true;
            if (x + y < z) return false;
            if (x == 0) return y == z;
            if (y == 0) return x == z;
            var gcd = Gcd(x, y);
            return z % gcd == 0;
        }

        private int Gcd(int x, int y)
        {
            var cp = x - y;
            if (cp == 0) return x;
            else if (cp < 0) return Gcd(x, -cp);
            else return Gcd(cp, y);
        }
    }
}
