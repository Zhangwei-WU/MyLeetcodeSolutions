
namespace LeetCode.P65
{
    using System.Text.RegularExpressions;

    public class Solution
    {
        public bool IsNumber(string s)
        {
            var regex1 = new Regex(@"^\s*(\+|\-)?(\d+\.?|\d*\.\d+)(e(\+|\-)?\d+)?\s*$");
            return regex1.IsMatch(s);
        }
    }
}
