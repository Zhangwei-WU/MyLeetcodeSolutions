
namespace LeetCode.P1108
{
    using System.Text;
    public class Solution
    {
        public string DefangIPaddr(string address)
        {
            var sb = new StringBuilder(address.Length + 6);

            foreach(var c in address)
            {
                if (c == '.') sb.Append("[.]");
                else sb.Append(c);
            }

            return sb.ToString();
        }
    }
}