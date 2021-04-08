using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Domain
{
    public class BeerArticleEntity
    {

        public int BeerId { get; set; }

        public int ArticleId { get; set; }

        public string BrandName { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public string PricePerUnitText { get; set; }

        public decimal PricePerUnit { get; set; }

        public string DescriptionText { get; set; }

        public string Image { get; set; }

        public int AmountOfBottles { get; set; }


    }
}
