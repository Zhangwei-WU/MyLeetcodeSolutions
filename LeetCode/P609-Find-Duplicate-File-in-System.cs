namespace LeetCode.P609
{
    using System.Collections.Generic;

    public class Solution
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            Dictionary<string, IList<string>> reverseIndex = new Dictionary<string, IList<string>>();
            for (int i = 0, len = paths.Length; i < len; i++)
            {
                var path = paths[i];
                var arr = path.Split(' ');
                var dir = arr[0];
                for (int j = 1, dlen = arr.Length; j < dlen; j++)
                {
                    var file = arr[j];
                    var idx = file.IndexOf('(');
                    var fileName = file.Substring(0, idx);
                    var content = file.Substring(idx + 1, file.Length - idx - 2);
                    if (!reverseIndex.TryGetValue(content, out IList<string> files))
                    {
                        files = new List<string>();
                        reverseIndex.Add(content, files);
                    }

                    files.Add(dir + "/" + fileName);
                }
            }

            var result = new List<IList<string>>(reverseIndex.Count);
            foreach (var files in reverseIndex.Values)
            {
                if (files.Count == 1) continue;
                result.Add(files);
            }

            return result;
        }
    }
}
