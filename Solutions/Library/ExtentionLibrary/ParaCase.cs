using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtensionLibrary
{
    public static class ParaCase
    {
        public static string ToParaCase(this string para)
        {
            if (string.IsNullOrEmpty(para)) return para;
            char[] charArray = para.ToCharArray();

            bool capitalizeNext = true;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (capitalizeNext && char.IsLetter(charArray[i]))
                {
                    charArray[i] = char.ToUpper(charArray[i]);
                    capitalizeNext = false;
                }
                else if (charArray[i] == '.')
                {
                    capitalizeNext = true;
                }
            }
            return new string(charArray);
        }

    }
}