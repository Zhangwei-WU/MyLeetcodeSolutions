
namespace LeetCode.P20
{
    using System.Collections.Generic;

    public class Solution
    {
        public bool IsValid(string s)
        {
            var len = s.Length;
            if (len % 2 == 1) return false;

            Stack<int> checkStack = new Stack<int>(len / 2 + 1);
            var chars = s.ToCharArray();

            for (var i = 0; i < len; i++)
            {
                var cnt = checkStack.Count;
                if (cnt > len - i) return false;

                switch (chars[i])
                {
                    case '{':
                        checkStack.Push(0);
                        break;

                    case '[':
                        checkStack.Push(1);
                        break;

                    case '(':
                        checkStack.Push(2);
                        break;

                    case '}':
                        if (cnt == 0 || checkStack.Pop() != 0) return false;
                        break;

                    case ']':
                        if (cnt == 0 || checkStack.Pop() != 1) return false;
                        break;

                    case ')':
                        if (cnt == 0 || checkStack.Pop() != 2) return false;
                        break;

                    default:
                        return false;
                }
            }

            return checkStack.Count == 0;
        }
    }
}
