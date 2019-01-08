namespace LeetCode.P17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return new string[0];
            var result = new char[digits.Length];
            var chars = digits.ToCharArray();

            return FindLetterComb(chars, 0, digits.Length, result).ToArray();
        }

        IEnumerable<string> FindLetterComb(char[] chars, int index, int length, char[] result)
        {
            if (index == length)
            {
                yield return new string(result);
                yield break;
            }
            switch (chars[index])
            {
                case '2':
                    for (var c = 'a'; c <= 'c'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;

                case '3':
                    for (var c = 'd'; c <= 'f'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;

                case '4':
                    for (var c = 'g'; c <= 'i'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                case '5':
                    for (var c = 'j'; c <= 'l'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                case '6':
                    for (var c = 'm'; c <= 'o'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                case '7':
                    for (var c = 'p'; c <= 's'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                case '8':
                    for (var c = 't'; c <= 'v'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                case '9':
                    for (var c = 'w'; c <= 'z'; c++)
                    {
                        result[index] = c;
                        foreach (var r in FindLetterComb(chars, index + 1, length, result)) yield return r;
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
