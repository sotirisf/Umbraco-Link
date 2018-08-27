using DotSee.Common.Link.Models;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Umbraco.Core.Models;

namespace DotSee.Common.Link
{
    public static class Link
    {
        public static LinkItem GetLink(this IPublishedContent item)
        {
            //if (!item.IsComposedOf(AbstractNcLinkItemModel.ModelTypeAlias)) { return null; }

            LinkItem link = new LinkItem();

            switch (item.DocumentTypeAlias)
            {
                case NcExternalLinkItemModel.ModelTypeAlias:
                    link.Url = GetLinkUrl(new NcExternalLinkItemModel(item));
                    break;

                case NcInternalLinkItemModel.ModelTypeAlias:
                    var itemConverted = new NcInternalLinkItemModel(item);
                    link.Url = GetLinkUrl(itemConverted);
                    link.InternalLinkId = GetLinkId(itemConverted);
                    link.IsInternal = true;
                    break;

                case NcFileLinkItemModel.ModelTypeAlias:
                    link.Url = GetLinkUrl(new NcFileLinkItemModel(item));
                    link.IsFile = true;
                    break;
            }
            if (link.Url != null)
            {
                link.UrlSecure = link.Url.Replace("http://", "https://");
                link.UrlNoHttp = link.Url.Replace("http://", "").Replace("https://", "");
            }
            var itemAdapted = new AbstractNcLinkItemModel(item);

            link.Target = (itemAdapted.OpenLinkInNewWindow) ? "_blank" : "_self";
            link.Caption = itemAdapted.Caption;
            string defaultAltValue = (itemAdapted.UseCaptionForAltAndTitle) ? itemAdapted.Caption : string.Empty;
            link.AltText = (!string.IsNullOrEmpty(itemAdapted.AltText)) ? itemAdapted.AltText : defaultAltValue;
            link.TitleText = (!string.IsNullOrEmpty(itemAdapted.TitleText)) ? itemAdapted.TitleText : defaultAltValue;

            if (itemAdapted.OtherAttributes != null && itemAdapted.OtherAttributes.Count() > 0)
            {
                link.OtherAttributes = new NameValueCollection();
                foreach (var v in itemAdapted.OtherAttributes.Select(x => new NcNameValuePairItemModel(x)))
                {
                    link.OtherAttributes.Add(v.NvName, v.NvValue);
                }
            }
            return link;
        }

        public static HtmlString GetLinkMarkup(this IPublishedContent item, ListDictionary attributes = null)
        {
            LinkItem link = item.GetLink();
            StringBuilder sb = new StringBuilder(string.Empty);
            sb.Append(string.Format("<a href=\"{0}\" target=\"{1}\"", link.Url, link.Target));
            if (attributes != null)
            {
                foreach (DictionaryEntry attr in attributes)
                {
                    sb.Append(string.Format(" {0}=\"{1}\"", attr.Key, attr.Value));
                }
            }

            sb.Append(!string.IsNullOrEmpty(link.TitleText) ? string.Format(" title=\"{0}\"", link.TitleText) : null);
            sb.Append(!string.IsNullOrEmpty(link.AltText) ? string.Format(" alt=\"{0}\"", link.AltText) : null);
            if (link.OtherAttributes != null && link.OtherAttributes.Count > 0)
            {
                foreach (string v in link.OtherAttributes.AllKeys)
                {
                    sb.Append(string.Format(" {0}=\"{1}\"", v, link.OtherAttributes[v].ToString()));
                }
            }
            sb.Append(">");
            sb.Append(link.Caption);
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public static string GetLinkUrl(NcExternalLinkItemModel item)
        {
            return (item.ExternalLink.ForceHttp());
        }

        public static string GetLinkUrl(NcInternalLinkItemModel item)
        {
            if (item.InternalLink == null || item.InternalLink.Count() == 0) { return null; }

            StringBuilder sb = new StringBuilder(item.InternalLink.First().Url);

            if (!string.IsNullOrEmpty(item.InternalLinkQuerystringParameters))
            {
                sb.Append("?");
                sb.Append(item.InternalLinkQuerystringParameters);
            }
            if (!string.IsNullOrEmpty(item.InternalLinkAnchor))
            {
                sb.Append("#");
                sb.Append(item.InternalLinkAnchor);
            }
            return (sb.ToString());
        }

        public static string GetLinkUrl(NcFileLinkItemModel item)
        {
            return (item.FileLink.Url);
        }

        public static int GetLinkId(NcInternalLinkItemModel item)
        {
            if (item.InternalLink == null || item.InternalLink.Count() == 0) { return 0; }
            return (item.InternalLink.First().Id);
        }
    }
}