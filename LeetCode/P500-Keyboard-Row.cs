namespace LeetCode.P500
{
    using System.Collections.Generic;

    public class Solution
    {
        public string[] FindWords(string[] words)
        {
            var mappings = new int[]
            {
                2,3,3,2,1,2,2,2,1,2,2,2,3,3,1,1,1,1,2,1,1,3,1,3,1,3,
                0,0,0,0,0,0,
                2,3,3,2,1,2,2,2,1,2,2,2,3,3,1,1,1,1,2,1,1,3,1,3,1,3
            };

            var result = new List<string>(words.Length);
            foreach(var word in words)
            {
                var idx = mappings[word[0] - 'A'];
                var ret = true;
                foreach(var c in word)
                {
                    if(idx != mappings[c-'A'] )
                    {
                        ret = false;
                        break;
                    }
                }

                if(ret) result.Add(word);
            }

            return result.ToArray();
        }
    }
}
