

namespace LeetCode.P150
{
    using System.Collections.Generic;

    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> values = new Stack<int>();
            
            for (int i = 0, len = tokens.Length, left, right; i < len; i++)
            {
                var token = tokens[i];

                switch (token)
                {
                    case "+":
                        right = values.Pop(); left = values.Pop();
                        values.Push(left + right);
                        break;
                    case "-":
                        right = values.Pop(); left = values.Pop();
                        values.Push(left - right);
                        break;
                    case "*":
                        right = values.Pop(); left = values.Pop();
                        values.Push(left * right);
                        break;
                    case "/":
                        right = values.Pop(); left = values.Pop();
                        values.Push(left / right);
                        break;
                    default:
                        values.Push(int.Parse(token));
                        break;
                }
            }

            return values.Pop();
        }
    }
}