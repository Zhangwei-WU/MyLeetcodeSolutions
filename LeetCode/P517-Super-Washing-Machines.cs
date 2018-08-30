/* Problem 517. Super Washing Machines
 * https://leetcode.com/problems/super-washing-machines/description/
 * 
 * You have n super washing machines on a line. Initially, each washing machine has some dresses or is empty.
 * For each move, you could choose any m (1 ≤ m ≤ n) washing machines, and pass one dress of each washing machine to one of its adjacent washing machines at the same time .
 * Given an integer array representing the number of dresses in each washing machine from left to right on the line, you should find the minimum number of moves to make all the washing machines have the same number of dresses. If it is not possible to do it, return -1.
 * 
 * Example1
 * Input: [1,0,5]
 * Output: 3
 * Explanation: 
 * 1st move:    1     0 <-- 5    =>    1     1     4
 * 2nd move:    1 <-- 1 <-- 4    =>    2     1     3    
 * 3rd move:    2     1 <-- 3    =>    2     2     2   
 * 
 * Example2
 * Input: [0,3,0]
 * Output: 2
 * Explanation: 
 * 1st move:    0 <-- 3     0    =>    1     2     0    
 * 2nd move:    1     2 --> 0    =>    1     1     1     
 * 
 * Example3
 * Input: [0,2,0]
 * Output: -1
 * Explanation: 
 * It's impossible to make all the three washing machines have the same number of dresses. 
 * 
 * Note:
 * The range of n is [1, 10000].
 * The range of dresses number in a super washing machine is [0, 1e5].
 */

namespace LeetCode.P517
{
    public class Solution
    {
        public int FindMinMoves(int[] machines)
        {
            var len = machines.Length;
            if (len == 0 || len == 1) return 0;

            int[] left = new int[len + 1];
            for (var i = 0; i < len; i++) left[i + 1] = left[i] + machines[i];

            var total = left[len];
            if (total % len != 0) return -1;
            var target = total / len;

            for (var i = 0; i < len + 1; i++) left[i] -= i * target;

            return FindMinMoves(machines, left, 0, len, target);
        }

        public int FindMinMoves(int[] machines, int[] left, int start, int length, int target)
        {
            if (start < 0 || start + length > machines.Length || length <= 1) return 0;

            // find largest
            int li = start;
            int lm = 0;
            for (var i = start; i < start + length; i++)
            {
                if (machines[i] > lm)
                {
                    li = i;
                    lm = machines[i];
                }
            }

            if (lm == target) return 0;

            machines[li] = target;
            int remain = lm - target;
            int moveleft = -left[li];
            if (moveleft < 0) moveleft = 0;
            int moveright = 0;

            if (moveleft == 0) moveright = remain;
            else if (moveleft >= remain) moveleft = remain;
            else moveright = remain - moveleft;

            // move left as far as possible
            while (moveleft != 0)
            {
                var pos = li;
                for (; left[pos] < 0; pos--) ;
                var move = -left[pos + 1];
                moveleft -= move;
                machines[pos] += move;
                for (var i = pos + 1; i <= li; i++) left[i] += move;
            }

            while(moveright != 0)
            {
                var pos = li + 1;
                for (; left[pos] > 0; pos++) ;
                var move = left[pos - 1];
                moveright -= move;
                machines[pos - 1] += move;
                for (var i = li + 1; i < pos; i++) left[i] -= move;
            }

            return remain +
                (left[li] == 0
                ? FindMinMoves(machines, left, start, li - start, target) + FindMinMoves(machines, left, li + 1, start + length - li - 1, target)
                : FindMinMoves(machines, left, start, length, target));

        }
    }
}
