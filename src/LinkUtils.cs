namespace DotSee.Common.Link
{
    public static class LinkUtils
    {
        public static string ForceHttp(this string input, bool secure = false)
        {
            return (string.Concat((secure) ? "https://" : "http://", input.Replace("https://", "").Replace("http://", "")));
        }
    }
}