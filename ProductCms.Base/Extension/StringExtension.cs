using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Base.Extension
{
    public static class StringExtension
    {
        public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var fromLength = (from ?? string.Empty).Length;
            var startIndex = !string.IsNullOrEmpty(from)
                ? @this.IndexOf(from, comparison) + fromLength
                : 0;

            if (startIndex < fromLength) return string.Empty;

            var endIndex = !string.IsNullOrEmpty(until)
            ? @this.IndexOf(until, startIndex, comparison)
            : @this.Length;

            if (endIndex < 0) endIndex = @this.Length; //until end of string.

            var subString = @this.Substring(startIndex, endIndex - startIndex);
            return subString;
        }
    }
}
