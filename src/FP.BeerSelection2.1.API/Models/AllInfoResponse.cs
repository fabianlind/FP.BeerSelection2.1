using FP.BeerSelection2._1.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Models
{
    public class AllInfoResponse
    {

        public BeerArticleEntity MostExpensiveBeer { get; set; }

        public BeerArticleEntity CheapestBeer { get; set; }

        public BeerArticleEntity BiggestAmountOfBottles { get; set; }

        public List<BeerArticleEntity> ByExactPrice { get; set; }

    }
}
