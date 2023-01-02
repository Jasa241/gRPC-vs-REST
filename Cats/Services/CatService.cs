using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cats.Context;
using Cats.Models;
using Cats.UseCase;
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
            //var cats = catContext.Cats.ToList();
            CatList catList = new CatList();
            //foreach (var item in cats)
            //{
            //    catList.Cats.Add(new Cat { Id = item.Id, Raza = item.Raza });
            //}

            var cats = CatsUseCase.GetCats();

            foreach (var item in cats)
            {
                catList.Cats.Add(new Cat { Id = item.Id, Raza = item.raza, Description = item.description });
            }

            return Task.FromResult(catList);
        }
    }
}