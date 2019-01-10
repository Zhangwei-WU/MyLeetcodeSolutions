namespace LeetCode.P722
{
    using System.Collections.Generic;
    using System.Text;

    public class Solution
    {
        public IList<string> RemoveComments(string[] source)
        {
            var output = new List<string>();
            var sb = new StringBuilder();

            foreach (var token in StreamTokens(source))
            {
                if (token == "\n")
                {
                    if (sb.Length != 0)
                    {
                        output.Add(sb.ToString());
                        sb.Clear();
                    }

                    continue;
                }

                sb.Append(token);
            }

            return output;
        }

        private IEnumerable<string> StreamTokens(string[] source)
        {
            bool inBlockComment = false;
            bool inLineComment = false;
            
            foreach (var line in source)
            {
                if (string.IsNullOrEmpty(line)) continue;

                int start = 0, length = line.Length;
                while (start < length)
                {
                    if (inLineComment) break;

                    if(inBlockComment)
                    {
                        var blockCommentEnd = line.IndexOf("*/", start);
                        if (blockCommentEnd == -1) break;
                        start = blockCommentEnd + 2;
                        inBlockComment = false;
                        continue;
                    }

                    var blockCommentStart = line.IndexOf("/*", start);
                    var lineCommentStart = line.IndexOf("//", start);

                    // !inblockComment
                    if (lineCommentStart == -1 && blockCommentStart == -1)
                    {
                        yield return line.Substring(start);
                        break;
                    }
                    else if (lineCommentStart != -1 && (blockCommentStart == -1 || blockCommentStart > lineCommentStart))
                    {
                        inLineComment = true;
                        yield return line.Substring(start, lineCommentStart - start);
                        start = lineCommentStart + 2;
                    }
                    else
                    {
                        inBlockComment = true;
                        yield return line.Substring(start, blockCommentStart - start);
                        start = blockCommentStart + 2;
                    }
                }

                inLineComment = false;
                if(!inBlockComment) yield return "\n";
            }
        }
    }
}
