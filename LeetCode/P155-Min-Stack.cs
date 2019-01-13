namespace LeetCode.P155
{
    using System.Collections.Generic;
    
    public class MinStack
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> minIndex = new Stack<int>();
        
        public MinStack()
        {
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minIndex.Count == 0 || minIndex.Peek() > x) minIndex.Push(x);
            else minIndex.Push(minIndex.Peek());
        }

        public void Pop()
        {
            stack.Pop();
            minIndex.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minIndex.Peek();
        }
    }
}
