using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class Book
    {
        [JsonProperty(PropertyName = "kind")]
        public String Kind { get; set; }

        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "volumeInfo")]
        public ItemVolumeInfo VolumeInfo { get; set; }

        [JsonProperty(PropertyName = "saleInfo")]
        public ItemSaleInfo SaleInfo { get; set; }

        // aici e null ca am schimbat property name ca era la fel
        [JsonProperty(PropertyName = "volumeInfoDetailed")]
        public ItemVolumeInfo VolumeInfoDetailed { get; set; }

        [JsonProperty(PropertyName = "saleInfoDetailed")]
        public ItemSaleInfo SaleInfoDetailed { get; set; }

        [JsonProperty(PropertyName = "accessInfo")]
        public ItemAccessInfo AccessInfo { get; set; }

    }

    public class ItemVolumeInfo
    {

        [JsonProperty(PropertyName = "title")]
        public String Title { get; set; }

        [JsonProperty(PropertyName = "authors")]
        public List<String> Authors { get; set; }

        [JsonProperty(PropertyName = "publishedDate")]
        public String PublishedDate { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "pageCount")]
        public String PageCount { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public List<String> Category { get; set; }

        [JsonProperty(PropertyName = "averageRating")]
        public String AverageRating { get; set; }

        [JsonProperty(PropertyName = "imageLinks")]
        public ImageLinks ImageLinks { get; set; }

    }

    public class ImageLinks
    {
        [JsonProperty(PropertyName = "smallThumbnail")]
        public String SmallThumbnail { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public String Thumbnail { get; set; }
    }

    public class ItemSaleInfo
    {
        [JsonProperty(PropertyName = "country")]
        public String Country { get; set; }

        [JsonProperty(PropertyName = "saleability")]
        public String Saleability { get; set; }

        [JsonProperty(PropertyName = "retailPrice")]
        public RetailPrice RetailPrice { get; set; }

        [JsonProperty(PropertyName = "buyLink")]
        public String BuyLink { get; set; }
    }

    public class RetailPrice
    {
        [JsonProperty(PropertyName = "amount")]
        public String Amount { get; set; }

        [JsonProperty(PropertyName = "currencyCode")]
        public String CurrencyCode { get; set; }
    }

}
