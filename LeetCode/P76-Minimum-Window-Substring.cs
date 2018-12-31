namespace LeetCode.P76
{
    using System.Collections.Generic;

    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            var rlen = t.Length;
            Dictionary<char, int> required = new Dictionary<char, int>(rlen);
            foreach (var c in t)
            {
                if (!required.TryGetValue(c, out int n)) required.Add(c, 1);
                else required[c] = n + 1;
            }
            
            Dictionary<char, int> found = new Dictionary<char, int>(required.Count);
            foreach (var k in required.Keys) found.Add(k, 0);


            var slen = s.Length;

            var si = -1;
            var sl = slen + 1;

            var chars = s.ToCharArray();

            var lastDeleted = (char)0;
            for (int li = 0, lr = 0; lr < slen; lr++)
            {
                var c = chars[lr];
                if (!required.TryGetValue(c, out int rc))
                {
                    chars[lr] = (char)0;
                    continue;
                }
                
                found[c]++;

                if (lastDeleted == c || lastDeleted == (char)0 && Filled(found, required))
                {
                    for (; li <= lr; li++)
                    {
                        var c2 = chars[li];
                        if (c2 == (char)0 || !required.TryGetValue(c2, out int rc2) || --found[c2] >= rc2) continue;
                        
                        var nlen = lr - li + 1;
                        if (nlen < sl)
                        {
                            si = li;
                            sl = nlen;
                        }

                        lastDeleted = c2;
                        li++;
                        break;
                    }

                    if (sl == rlen) break;
                }
            }

            if (si == -1) return string.Empty;
            return s.Substring(si, sl);
        }

        public bool Filled(Dictionary<char, int> l, Dictionary<char, int> r)
        {
            foreach (var kv in r) if (kv.Value > l[kv.Key]) return false;
            return true;
        }
    }
}
