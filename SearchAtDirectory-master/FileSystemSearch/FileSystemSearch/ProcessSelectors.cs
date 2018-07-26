using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FileSystemSearch
{
    class ProcessSelectors
    {
        public static List<string> getAllSelectors()
        {
            List<string> result = new List<string>();
            StreamReader reader = File.OpenText(@"D:\selector.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<int> spaces = new List<int>();
                string pattern = @"\s";

                Regex expr = new Regex(pattern);
                MatchCollection matches = expr.Matches(line);

                foreach (Match match in matches)
                {
                    spaces.Add(match.Index);
                }

                if (line.Contains("createSelector"))
                {
                    int start = spaces[1] + 1;
                    int end = spaces[2] + 1;
                    result.Add(line.Substring(start, end - start));
                }
            }
            return result;
        }
        public static void writeResultToFile(List<string> selectors)
        {
            foreach (string selector in selectors)
            {
                using (StreamWriter sw = File.AppendText(@"D:\test.txt"))
                {
                    sw.WriteLine(selector);
                }

            }
        }
    }
}
