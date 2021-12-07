using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cats.Context;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace grpcserver
{
    public class CatService : Cats.CatsBase
    {
        private readonly ILogger<CatService> _logger;
        private CatsContext catContext;
        public CatService(ILogger<CatService> logger, CatsContext catsContext)
        {
            _logger = logger;
            catContext = catsContext;
        }
        public override Task<CatList> GetCats(Empty request, ServerCallContext context)
        {
            var cats = catContext.Cats.ToList();
            CatList catList = new CatList();
            foreach (var item in cats)
            {
                catList.Cats.Add(new Cat { Id = item.Id, Raza = item.Raza }); 
            }

            return Task.FromResult(catList);
        }
        public override Task<Cat> GetCat(CatId catId, ServerCallContext context)
        {
            try
            {
                var cat = catContext.Cats.Find(catId.Id);

                return Task.FromResult(cat);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override Task<Cat> CreateCat(Cat cat, ServerCallContext context)
        {
            try
            {
                catContext.Cats.Add(cat);
                catContext.SaveChanges();

                return Task.FromResult(cat);
            }
            catch (Exception)
            {
                return Task.FromResult(cat);
            }
        }
        public override Task<Cat> EditCat(Cat cat, ServerCallContext context)
        {
            try
            {
                catContext.Cats.Update(cat);
                catContext.SaveChanges();

                return Task.FromResult(cat);
            }
            catch (Exception)
            {
                return Task.FromResult(cat);
            }
        }
        public override Task<CatList> DeleteCat(CatId catId, ServerCallContext context)
        {
            var cat = catContext.Cats.Find(catId.Id);
            catContext.Cats.Remove(cat);
            catContext.SaveChanges();
            
            var cats = catContext.Cats.ToList();

            CatList catList = new CatList();
            foreach (var item in cats)
            {
                catList.Cats.Add(new Cat { Id = item.Id, Raza = item.Raza });
            }

            return Task.FromResult(catList);
        }
    }
}