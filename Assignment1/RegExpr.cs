using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var words = new List<string>();

            foreach (string line in lines)
            {
                var splitLine = line.Split(" ");
                words.AddRange(splitLine);
            }
            return words;
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
