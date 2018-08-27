using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace DotSee.Common.Link.Models
{
    /// <summary>AbstractNcLinkItem</summary>
    public partial interface IAbstractNcLinkItemModel : IPublishedContent
    {
        /// <summary>ALT text</summary>
        string AltText { get; }

        /// <summary>Caption</summary>
        string Caption { get; }

        /// <summary>Open Link in New Window</summary>
        bool OpenLinkInNewWindow { get; }

        /// <summary>Other Attributes</summary>
		IEnumerable<IPublishedContent> OtherAttributes { get; }

        /// <summary>TITLE text</summary>
        string TitleText { get; }

        /// <summary>Use Caption as ALT and TITLE values</summary>
        bool UseCaptionForAltAndTitle { get; }
    }

    //[PublishedContentModel("abstractNcLinkItem")]
    public partial class AbstractNcLinkItemModel : PublishedContentModel, IAbstractNcLinkItemModel
    {
#pragma warning disable 0109 // new is redundant
        public new const string ModelTypeAlias = "abstractNcLinkItem";
        public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

        public AbstractNcLinkItemModel(IPublishedContent content)
            : base(content)
        { }

#pragma warning disable 0109 // new is redundant

        public new static PublishedContentType GetModelContentType()
        {
            return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
        }

#pragma warning restore 0109

        public string AltText
        {
            get { return GetAltText(this); }
        }

        public static string GetAltText(IAbstractNcLinkItemModel that)
        {
            return that.GetPropertyValue<string>("altText");
        }

        public string Caption
        {
            get { return GetCaption(this); }
        }

        public static string GetCaption(IAbstractNcLinkItemModel that)
        {
            return that.GetPropertyValue<string>("caption");
        }

        public bool OpenLinkInNewWindow
        {
            get { return GetOpenLinkInNewWindow(this); }
        }

        public static bool GetOpenLinkInNewWindow(IAbstractNcLinkItemModel that)
        {
            return that.GetPropertyValue<bool>("openLinkInNewWindow");
        }

        public string TitleText
        {
            get { return GetTitleText(this); }
        }

        public IEnumerable<IPublishedContent> OtherAttributes
        {
            get { return GetOtherAttributes(this); }
        }

        /// <summary>Static getter for Other Attributes</summary>
        public static IEnumerable<IPublishedContent> GetOtherAttributes(IAbstractNcLinkItemModel that) { return that.GetPropertyValue<IEnumerable<IPublishedContent>>("otherAttributes"); }

        public static string GetTitleText(IAbstractNcLinkItemModel that)
        {
            return that.GetPropertyValue<string>("titleText");
        }

        public bool UseCaptionForAltAndTitle
        {
            get { return GetUseCaptionForAltAndTitle(this); }
        }

        /// <summary>Static getter for Use Caption as ALT and TITLE values</summary>
        public static bool GetUseCaptionForAltAndTitle(IAbstractNcLinkItemModel that) { return that.GetPropertyValue<bool>("useCaptionForAltAndTitle"); }
    }
}