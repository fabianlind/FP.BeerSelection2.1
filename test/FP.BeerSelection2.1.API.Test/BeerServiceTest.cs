using FP.BeerSelection2._1.API.Domain;
using FP.BeerSelection2._1.API.Repositories;
using FP.BeerSelection2._1.API.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FP.BeerSelection2._1.API.Test
{
    public class BeerServiceTest
    {
        [Fact]
        public async Task GetFlatBeerListAsync__GetsFlatBeerList()
        {
            // 1. arrange

            var mockRepository = Substitute.For<IBeerRepository>();

            mockRepository.GetBeerListByUrlAsync("beerURL").Returns(b => new List<BeerEntity>
            {
                new BeerEntity
                {
                    BeerId = 1,
                    BrandName = "HolyBeer",
                    Name = "HolyBeerToo",
                    DescriptionText = "This Beer is holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 2,
                            ShortDescription = "20 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                }
            });

            var sut = new BeerService(mockRepository);

            // 2. act

            var result = await sut.GetFlatBeerListAsync("beerURL");

            // 3. assert

            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();

            Assert.Equal("HolyBeer", firstResult.BrandName);

            Assert.Equal(1.80m, firstResult.PricePerUnit);

            Assert.Equal(20, firstResult.AmountOfBottles);
        }

        [Fact]
        public async Task GetBeerWithMostBottlesAsync__GetsMostAmountOfBottles()
        {
            // 1. arrange

            var mockRepository = Substitute.For<IBeerRepository>();

            mockRepository.GetBeerListByUrlAsync("beerURL").Returns(b => new List<BeerEntity>
            {
                new BeerEntity
                {
                    BeerId = 1,
                    BrandName = "HolyBeer",
                    Name = "HolyBeerToo",
                    DescriptionText = "This Beer is holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 2,
                            ShortDescription = "20 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                new BeerEntity
                {
                    BeerId = 2,
                    BrandName = "HolyBeerTwo",
                    Name = "HolyBeerTooTwo",
                    DescriptionText = "This Beer is also holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 3,
                            ShortDescription = "10 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                }
            });

            var sut = new BeerService(mockRepository);

            // 2. act

            var result = await sut.GetBeerWithMostBottlesAsync("beerURL");

            // 3. assert

            Assert.NotNull(result);

            Assert.Equal(2, result.ArticleId);

            Assert.Equal(20, result.AmountOfBottles);
        }

        [Fact]
        public async Task GetCheapestBeerAsync__GetsCheapestBeer()
        {
            // 1. arrange

            var mockRepository = Substitute.For<IBeerRepository>();

            mockRepository.GetBeerListByUrlAsync("beerURL").Returns(b => new List<BeerEntity>
            {
                new BeerEntity
                {
                    BeerId = 1,
                    BrandName = "HolyBeer",
                    Name = "HolyBeerToo",
                    DescriptionText = "This Beer is holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 2,
                            ShortDescription = "20 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                new BeerEntity
                {
                    BeerId = 2,
                    BrandName = "HolyBeerTwo",
                    Name = "HolyBeerTooTwo",
                    DescriptionText = "This Beer is also holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 3,
                            ShortDescription = "10 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                new BeerEntity
                {
                    BeerId = 3,
                    BrandName = "CheapBeerCompany",
                    Name = "CheapestBeer",
                    DescriptionText = "Cheapest Beer in Town!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 4,
                            ShortDescription = "33 x 1,0L (Glas)",
                            Price = 15.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(0,80 €/Liter)",
                            Image = "image2"
                        }
                    }
                }
            });

            var sut = new BeerService(mockRepository);

            // 2. act

            var result = await sut.GetCheapestBeerAsync("beerURL");

            // 3. assert

            Assert.NotNull(result);

            Assert.Equal(4, result.ArticleId);

            Assert.Equal(0.80m, result.PricePerUnit);
        }

        [Fact]
        public async Task GetMostExpensiveBeerAsync__GetsMostExpensiveBeer()
        {
            // 1. arrange

            var mockRepository = Substitute.For<IBeerRepository>();

            mockRepository.GetBeerListByUrlAsync("beerURL").Returns(b => new List<BeerEntity>
            {
                new BeerEntity
                {
                    BeerId = 1,
                    BrandName = "HolyBeer",
                    Name = "HolyBeerToo",
                    DescriptionText = "This Beer is holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 2,
                            ShortDescription = "20 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                new BeerEntity
                {
                    BeerId = 2,
                    BrandName = "HolyBeerTwo",
                    Name = "HolyBeerTooTwo",
                    DescriptionText = "This Beer is also holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 3,
                            ShortDescription = "10 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                
                new BeerEntity
                {
                    BeerId = 4,
                    BrandName = "ExpensiveBeerCompany",
                    Name = "ExpensiveBeer",
                    DescriptionText = "Most expensive Beer in Town!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 4,
                            ShortDescription = "24 x 1,0L (Glas)",
                            Price = 19.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(2,00 €/Liter)",
                            Image = "image2"
                        }
                    }
                }
            });

            var sut = new BeerService(mockRepository);

            // 2. act

            var result = await sut.GetMostExpensiveBeerAsync("beerURL");

            // 3. assert

            Assert.NotNull(result);

            Assert.Equal(4, result.ArticleId);

            Assert.Equal(19.99m, result.Price);
        }


        [Fact]
        public async Task GetBeerByExactPriceAsync__GetsBeerByAnExactPrice()
        {
            // 1. arrange

            var exactPrice = 20.99m;

            var mockRepository = Substitute.For<IBeerRepository>();

            mockRepository.GetBeerListByUrlAsync("beerURL").Returns(b => new List<BeerEntity>
            {
                new BeerEntity
                {
                    BeerId = 1,
                    BrandName = "HolyBeer",
                    Name = "HolyBeerToo",
                    DescriptionText = "This Beer is holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 2,
                            ShortDescription = "20 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },
                new BeerEntity
                {
                    BeerId = 2,
                    BrandName = "HolyBeerTwo",
                    Name = "HolyBeerTooTwo",
                    DescriptionText = "This Beer is also holy!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 3,
                            ShortDescription = "10 x 0,5L (Glas)",
                            Price = 17.99m,
                            Unit = "Liter",
                            PricePerUnitText = "(1,80 €/Liter)",
                            Image = "image"

                        }
                    }
                },

                new BeerEntity
                {
                    BeerId = 4,
                    BrandName = "ExactPriceBeerCompany",
                    Name = "ExactBeerByPrice",
                    DescriptionText = "The Beer with the exact price of...!",

                    Articles = new List<ArticleEntity>
                    {
                        new ArticleEntity
                        {
                            ArticleId = 4,
                            ShortDescription = "24 x 1,0L (Glas)",
                            Price = exactPrice,
                            Unit = "Liter",
                            PricePerUnitText = "(2,10 €/Liter)",
                            Image = "image3"
                        }
                    }
                }
            });

            var sut = new BeerService(mockRepository);            

            // 2. act

            var result = await sut.GetBeerByExactPriceAsync("beerURL", exactPrice);

            // 3. assert

            Assert.NotEmpty(result);
            Assert.Single(result);

            var firstResult = result.First();

            Assert.Equal(4, firstResult.ArticleId);

            Assert.Equal(20.99m, firstResult.Price);
        }

    }
}
