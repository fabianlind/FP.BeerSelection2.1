using FP.BeerSelection2._1.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Abstractions
{
    public interface IBeerService
    {

        Task<BeerArticleEntity> GetMostExpensiveBeerAsync(string beerListURL);

        Task<BeerArticleEntity> GetCheapestBeerAsync(string beerListURL);

        Task<List<BeerArticleEntity>> GetBeerByExactPriceAsync(string beerListURL, decimal exactPrice);

        Task<BeerArticleEntity> GetBeerWithMostBottlesAsync(string beerListURL);

    }
}
