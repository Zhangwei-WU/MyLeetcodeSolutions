namespace LeetCode.P412
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<string> FizzBuzz(int n)
        {
            var result = new string[n];

            for (var i = 1; i <= n; i++)
            {
                var fizz = i % 3 == 0;
                var buzz = i % 5 == 0;
                result[i - 1] = fizz && buzz
                    ? "FizzBuzz"
                    : fizz
                    ? "Fizz"
                    : buzz
                    ? "Buzz"
                    : i.ToString();
            }

            return result;
        }
    }
}
