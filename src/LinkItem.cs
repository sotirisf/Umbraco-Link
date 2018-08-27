using System;
using System.Collections.Specialized;

namespace DotSee.Common.Link
{
    public class LinkItem
    {
        public LinkItem()
        {
            Url = "";
            Target = "_self";
            InternalLinkId = 0;
            IsInternal = false;
            IsFile = false;
        }

        public bool IsInternal { get; set; }
        public bool IsFile { get; set; }

        public string Url { get; set; }

        public string UrlSecure { get; set; }

        public string Target { get; set; }

        public string UrlNoHttp { get; set; }

        public string Caption { get; set; }

        public string AltText { get; set; }

        public string TitleText { get; set; }

        public int InternalLinkId { get; set; }

        public NameValueCollection OtherAttributes { get; set; }
        
    }
}