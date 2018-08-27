using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace DotSee.Common.Link.Models
{
    /// <summary>NcNameValuePairItem</summary>

    public partial class NcNameValuePairItemModel : PublishedContentModel
    {
#pragma warning disable 0109 // new is redundant
        public new const string ModelTypeAlias = "ncNameValuePairItem";
        public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

        public NcNameValuePairItemModel(IPublishedContent content)
            : base(content)
        { }

#pragma warning disable 0109 // new is redundant

        public new static PublishedContentType GetModelContentType()
        {
            return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
        }

#pragma warning restore 0109

        public string NvName
        {
            get { return this.GetPropertyValue<string>("nvName"); }
        }

        public string NvValue
        {
            get { return this.GetPropertyValue<string>("nvValue"); }
        }
    }
}