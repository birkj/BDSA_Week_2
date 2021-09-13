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
                foreach (string substring in substrings)
                {
                    yield return substring;
                }
            }
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
            // Regex rx = new Regex(@$"(?P<{tag}><[^b](?:\s|>)[^<>]+>(?P<text>[^<]+))");

            string pattern0 = $@"(?<{tag}><[^b](?:\s|>)[^<>]+>(?<text>[^<]+))";
            string pattern1 = @"(?<partTwo>(?<statTag>[<]{0,4}[>])|(?<endTag>[<\/].{0,4}[>]))";

            if (Regex.IsMatch(html, pattern0))
            {

                foreach (Match m in Regex.Matches(html, pattern0))
                {
                    GroupCollection groups = m.Groups;
                    yield return groups["text"].ToString();
                }
            }
            else
            {
                yield return Regex.Replace(html, pattern1, "").Trim();
            }
        }
    }
}
