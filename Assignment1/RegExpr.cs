using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var words = new List<string>();

            foreach (string line in lines)
            {
                var substrings = Regex.Split(line.Trim(), "\\s+");
                words.AddRange(substrings);
            }
            return words;
        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            string pattern = @"(?<width>\d+)x(?<height>\d+)";

            foreach (string input in resolutions)
            {
                Match m = Regex.Match(input, pattern);
                yield return (int.Parse(m.Groups["width"].ToString()), int.Parse(m.Groups["height"].ToString()));
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
