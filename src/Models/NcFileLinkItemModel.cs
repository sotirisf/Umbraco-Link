using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace DotSee.Common.Link.Models
{
    /// <summary>NC File Link Item</summary>
    //[PublishedContentModel("ncFileLinkItem")]
    public partial class NcFileLinkItemModel : PublishedContentModel, IAbstractNcLinkItemModel
    {
#pragma warning disable 0109 // new is redundant
        public new const string ModelTypeAlias = "ncFileLinkItem";
        public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

        public NcFileLinkItemModel(IPublishedContent content)
            : base(content)
        { }

#pragma warning disable 0109 // new is redundant

        public new static PublishedContentType GetModelContentType()
        {
            return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
        }

#pragma warning restore 0109

        ///<summary>
        /// Link to File: If you specify a link here, internal link is ignored
        ///</summary>

        public IPublishedContent FileLink
        {
            get { return this.GetPropertyValue<IPublishedContent>("fileLink"); }
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