using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class FormatTextExtensions
    {
        public static string FormatText(this string text, int len, string suffix)
        {
            if (len != -1 && text.Length > len)
            {
                int pos = text.LastIndexOfAny(" ,.".ToCharArray(), len);
                if (pos == -1)
                    pos = len;
                text = text.Substring(0, pos) + suffix;
            }
            return text;
        }
    }
}
