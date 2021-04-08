using FP.BeerSelection2._1.API.Abstractions;
using FP.BeerSelection2._1.API.Domain;
using FP.BeerSelection2._1.API.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Services
{
    public class BeerService : IBeerService
    {

        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<BeerArticleEntity> GetMostExpensiveBeerAsync(string beerListURL)
        {
            var beerList = await GetFlatBeerListAsync(beerListURL);

            var expensiveBeer = beerList.OrderByDescending(b => b.PricePerUnit).FirstOrDefault();

            return expensiveBeer;
        }

        public async Task<BeerArticleEntity> GetCheapestBeerAsync(string beerListURL)
        {
            var beerList = await GetFlatBeerListAsync(beerListURL);

            var cheapestBeer = beerList.OrderBy(b => b.PricePerUnit).FirstOrDefault();

            return cheapestBeer;
        }

        public async Task<List<BeerArticleEntity>> GetBeerByExactPriceAsync(string beerListURL, decimal exactPrice)
        {
            var beerList = await GetFlatBeerListAsync(beerListURL);

            var exactPriceBeerList = beerList
                .Where(b => b.Price == exactPrice)
                .OrderBy(b => b.PricePerUnit)
                .ToList();

            return exactPriceBeerList;

        }

        public async Task<BeerArticleEntity> GetBeerWithMostBottlesAsync(string beerListURL)
        {
            var beerList = await GetFlatBeerListAsync(beerListURL);

            var beerMostAmountBottles = beerList.OrderByDescending(b => b.AmountOfBottles).FirstOrDefault();

            return beerMostAmountBottles;
        }


        public async Task<List<BeerArticleEntity>> GetFlatBeerListAsync(string beerListURL)
        {            
            var beerList = await _beerRepository.GetBeerListByUrlAsync(beerListURL);

            var flatList = new List<BeerArticleEntity>();

            foreach(var beer in beerList)
            {
                foreach(var article in beer.Articles)
                {
                    flatList.Add(new BeerArticleEntity
                    {
                        ArticleId = article.ArticleId,
                        BeerId = beer.BeerId,
                        BrandName = beer.BrandName,
                        Name = beer.Name,
                        ShortDescription = article.ShortDescription,
                        Price = article.Price,
                        Unit = article.Unit,
                        PricePerUnitText = article.PricePerUnitText,
                        PricePerUnit = article.GetPricePerUnit(),
                        AmountOfBottles = article.GetAmountOfBottles(),
                        DescriptionText = beer.DescriptionText,
                        Image = article.Image

                    });
                }
            }

            return flatList;
        }

    }
}
