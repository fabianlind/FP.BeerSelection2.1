using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Domain
{
    public class ArticleEntity
    {

        [JsonProperty("id")]
        public int ArticleId { get; set; } 

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        public int GetAmountOfBottles()
        {
            var amountOfBottles = ShortDescription.Split(" x ").First().Trim();

            return int.Parse(amountOfBottles);
        }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("pricePerUnitText")]
        public string PricePerUnitText { get; set; }

        public decimal GetPricePerUnit()
        {
            var pricePerUnit = PricePerUnitText.Replace("(", "").Replace(" €/Liter)", "");

            return decimal.Parse(pricePerUnit);
        }

        [JsonProperty("image")]
        public string Image { get; set; }


    }
}
