using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Domain
{
    public class BeerEntity
    {
        [JsonProperty("id")]
        public int BeerId { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("descriptionText")]
        public string DescriptionText { get; set; }

        [JsonProperty("articles")]
        public List<ArticleEntity> Articles { get; set; }

    }
}
