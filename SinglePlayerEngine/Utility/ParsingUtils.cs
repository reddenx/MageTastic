using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Utility
{
    static class ParsingUtils
    {
        public static string[] GetBetween(string str, char start, char end, int offset = 0)
        {
            var datas = new List<string>();
            var startIndex = str.IndexOf(start, offset) + 1;
            while (startIndex > 0)
            {
                var endIndex = str.IndexOf(end, offset + startIndex);
                var between = str.Substring(startIndex, endIndex - startIndex);

                datas.Add(between);

                startIndex = str.IndexOf(start, startIndex) + 1;
            }
            return datas.ToArray();
        }
    }
}
