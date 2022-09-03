using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        //Veritabanı bağlantısı için kullanılacak repository. Base Repositary class'ında default olarak tanımlanmış metotlar bulunmakta. 
        //Default metotların dışında metot tanımlanmak istenirse burada tanımlanır.
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }
    }
}