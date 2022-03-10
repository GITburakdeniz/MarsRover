using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NavigationLibrary
{
    public static class NavigationHandling
    {
        public static bool IsValidTurn(this string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (Regex.IsMatch(str, @"^[LMR]+$"))
                return true;

            return false;
        }
    }
}
