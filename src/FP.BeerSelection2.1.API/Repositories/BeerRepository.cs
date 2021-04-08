using FP.BeerSelection2._1.API.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        public async Task<List<BeerEntity>> GetBeerListByUrlAsync(string beerArticlesURL)
        {
            string json;

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync(beerArticlesURL);
            }

            var beerList = JsonConvert.DeserializeObject<List<BeerEntity>>(json);

            return beerList;
        }
    }
}
