using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringExtension
    {
        public static int IndexOfEx(this string str,string value,int startIndex=0, StringComparison stringComparison=StringComparison.OrdinalIgnoreCase)
        {
            return str.IndexOf(value, startIndex, stringComparison);
        }
    }
}
