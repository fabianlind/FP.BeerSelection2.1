using FP.BeerSelection2._1.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.BeerSelection2._1.API.Repositories
{
    public interface IBeerRepository
    {

        public Task<List<BeerEntity>> GetBeerListByUrlAsync(string beerArticlesURL);

    }
}
