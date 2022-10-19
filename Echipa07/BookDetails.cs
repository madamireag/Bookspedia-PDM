using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class BookDetails: Book
    {
        [JsonProperty(PropertyName = "volumeInfo")]
        public ItemVolumeInfo VolumeInfoDetailed { get; set; }

        [JsonProperty(PropertyName = "saleInfo")]
        public ItemSaleInfo SaleInfoDetailed { get; set; }

        [JsonProperty(PropertyName = "accessInfo")]
        public ItemAccessInfo AccessInfo { get; set; }
    }

    public class ItemAccessInfo
    {
        [JsonProperty(PropertyName = "webReaderLink")]
        public String WebReaderLink { get; set; }
    }
}
