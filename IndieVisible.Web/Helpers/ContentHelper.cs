using System;
using System.Text.RegularExpressions;

namespace IndieVisible.Web.Helpers
{
    public static class ContentHelper
    {
        public static string FormatContentToShow(string content)
        {
            //group 1 <figure
            //group 2 <img src="
            //group 5 oembed
            //group 6 abre parenteses
            //group 7 url
            //group 8 fecha parenteses
            //group 10 oembed ending
            //group 11 figure ending

            string patternUrl = @"(<figure class=""image"">)?(<img(.?)?(data-)?src="")?(<figure class=""media""><oembed url=""|<figure class=""media""><div data-oembed-url=""|<oembed>)?(\()?([(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*))""?(\))?(<\/oembed>|><\/oembed><\/figure>)?(><\/figure>)?(.>)?";

            Regex regexImage = new Regex(patternUrl);

            MatchCollection matchesImg = regexImage.Matches(content);

            foreach (Match match in matchesImg)
            {
                string toReplace = match.Groups[0].Value;
                string imagePrefix = match.Groups[2].Value;
                string oembedPrefix = match.Groups[5].Value;
                string openParenthesis = match.Groups[6].Value;
                string url = match.Groups[7].Value;
                string closeParenthesis = match.Groups[9].Value;

                url = !url.TrimStart('(').TrimEnd(')').ToLower().StartsWith("http") ? String.Format("http://{0}", url) : url;


                string newText = string.Empty;
                if (!string.IsNullOrWhiteSpace(imagePrefix))
                {
                    newText = String.Format("<img src=\"{0}\" />", url);
                }
                else if (!string.IsNullOrWhiteSpace(oembedPrefix))
                {
                    newText = String.Format(@"<div class=""videoWrapper""><oembed>{0}</oembed></div>", url);
                }
                else
                {
                    newText = string.Format(@"<a href=""{0}"" target=""_blank"" style=""font-weight:500"">{0}</a>", url);
                }

                if (!string.IsNullOrWhiteSpace(openParenthesis) && !string.IsNullOrWhiteSpace(closeParenthesis))
                {
                    newText = String.Format("({0})", newText);
                }

                var templateUrlCkEditor = String.Format("<a href=\"{0}\">{0}</a>", url);

                var isAlreadyUrl = Regex.IsMatch(content, templateUrlCkEditor);

                if (!isAlreadyUrl)
                {
                    content = content.Replace(toReplace, newText); 
                }
            }

            return content;
        }
    }
}
