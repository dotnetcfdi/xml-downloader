using System.Text.RegularExpressions;

namespace XmlDownloader.Common
{
    public static class Helpers
    {
        public static string NoSpaces(string input)
        {

            input = Regex.Replace(input, @"/^\\h*/m", "");// A: remove horizontal spaces at beginning
            input = Regex.Replace(input, @"/\\h*\r?\n/m", "");// B: remove horizontal spaces + optional CR + LF
            input = Regex.Replace(input, @"/\?></", "?>\n<");// C: xml definition on its own line
            return input;
        }
    }
}
