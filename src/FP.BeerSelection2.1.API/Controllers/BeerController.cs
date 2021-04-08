using FP.BeerSelection2._1.API.Abstractions;
using FP.BeerSelection2._1.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Controllers
{
    [ApiController]
    [Route("beers")]
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet("most-expensive-or-cheapest")]
        public async Task<CheapestAndMostExpensiveResponse> GetCheapestAndMostExpensiveAsync([FromQuery] string url)
        {
            var mostExpensive = await _beerService.GetMostExpensiveBeerAsync(url);
            var cheapestBeer = await _beerService.GetCheapestBeerAsync(url);

            return new CheapestAndMostExpensiveResponse
            {
                CheapestBeer = cheapestBeer,
                MostExpensiveBeer = mostExpensive
            };
        }

        [HttpGet("exact-by-price")]
        public async Task<ByExactPriceResponse> GetByExactPriceAsync([FromQuery] string url, [FromQuery] decimal byExactPrice = 17.99m)
        {
            var byExactPriceBeer = await _beerService.GetBeerByExactPriceAsync(url, byExactPrice);

            return new ByExactPriceResponse
            {
                ByExactPriceBeer = byExactPriceBeer
            };
        }

        [HttpGet("biggest-amount-bottles")]
        public async Task<BiggestAmountOfBottlesResponse> GetBiggestAmountOfBottlesAsync([FromQuery] string url)
        {
            var biggestAmountBottlesBeer = await _beerService.GetBeerWithMostBottlesAsync(url);

            return new BiggestAmountOfBottlesResponse
            {
                BiggestAmountOfBottles = biggestAmountBottlesBeer
            };
        }

        [HttpGet("all-info")]
        public async Task<AllInfoResponse> GetAllInfoAsync([FromQuery] string url, [FromQuery] decimal byExactPrice = 17.99m)
        {
            var mostExpensive = await _beerService.GetMostExpensiveBeerAsync(url);
            var cheapestBeer = await _beerService.GetCheapestBeerAsync(url);

            var biggestAmountBottlesBeer = await _beerService.GetBeerWithMostBottlesAsync(url);

            var byExactPriceBeer = await _beerService.GetBeerByExactPriceAsync(url, byExactPrice);

            return new AllInfoResponse
            {
                CheapestBeer = cheapestBeer,
                MostExpensiveBeer = mostExpensive,
                BiggestAmountOfBottles = biggestAmountBottlesBeer,
                ByExactPrice = byExactPriceBeer
            };
        }
    }
}
