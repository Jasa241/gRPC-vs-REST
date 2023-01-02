using Cats.Models;
using System.Collections.Generic;

namespace Cats.UseCase
{
    public static class CatsUseCase
    {
        public static List<Cat> GetCats() {
            return new List<Cat>() { 
                new Cat(){ Id=1,raza="1",description="1"},
                new Cat(){ Id=2,raza="2",description="2"},
            };
        }
    }
}
