using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace DotSee.Common.Link.Models
{
    /// <summary>NC Internal Link Item</summary>
    //[PublishedContentModel("ncInternalLinkItem")]
    public partial class NcInternalLinkItemModel : PublishedContentModel, IAbstractNcLinkItemModel
    {
#pragma warning disable 0109 // new is redundant
        public new const string ModelTypeAlias = "ncInternalLinkItem";
        public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

        public NcInternalLinkItemModel(IPublishedContent content)
            : base(content)
        { }

#pragma warning disable 0109 // new is redundant

        public new static PublishedContentType GetModelContentType()
        {
            return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
        }

#pragma warning restore 0109

        ///<summary>
        /// Internal Link
        ///</summary>

        public IEnumerable<IPublishedContent> InternalLink
        {
            get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("internalLink"); }
        }

        ///<summary>
        /// Internal Link Anchor: Use this in combination with the internal link to navigate to a specific part of the page.
        ///</summary>

        public string InternalLinkAnchor
        {
            get { return this.GetPropertyValue<string>("internalLinkAnchor"); }
        }

        ///<summary>
        /// Internal Link Querystring Parameters: Enter any additional querystring parameters you want to add to the internal link, in the form "a=1&b=2" (without the question mark).
        ///</summary>

        public string InternalLinkQuerystringParameters
        {
            get { return this.GetPropertyValue<string>("internalLinkQuerystringParameters"); }
        }

        ///<summary>
        /// ALT text
        ///</summary>

        public string AltText
        {
            get { return AbstractNcLinkItemModel.GetAltText(this); }
        }

        ///<summary>
        /// Caption: If you don't fill this field, the element will not be displayed at all.
        ///</summary>

        public string Caption
        {
            get { return AbstractNcLinkItemModel.GetCaption(this); }
        }

        ///<summary>
        /// Open Link in New Window
        ///</summary>

        public bool OpenLinkInNewWindow
        {
            get { return AbstractNcLinkItemModel.GetOpenLinkInNewWindow(this); }
        }

        ///<summary>
        /// TITLE text
        ///</summary>

        public string TitleText
        {
            get { return AbstractNcLinkItemModel.GetTitleText(this); }
        }

        ///<summary>
        /// Use Caption as ALT and TITLE values: Check this box if you want the caption field's value to be used in the ALT and TITLE attributes as well if their respective fields are left empty.
        ///</summary>

        public bool UseCaptionForAltAndTitle
        {
            get { return AbstractNcLinkItemModel.GetUseCaptionForAltAndTitle(this); }
        }

        public IEnumerable<IPublishedContent> OtherAttributes
        {
            get { return AbstractNcLinkItemModel.GetOtherAttributes(this); }
        }
    }
}