using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class Items
    {
        [JsonProperty(PropertyName = "items")]
        public List<Book> Itemss { get; set; }
    }
}
