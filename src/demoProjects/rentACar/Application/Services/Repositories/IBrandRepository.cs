using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Services.Repositories
{
    public interface IBrandRepository: IAsyncRepository<Brand>, IRepository<Brand>
    {
        //CRUD operasyonları repository'lerden geliyor ancak Brand'e özel operasyonlar olursa buraya eklenecek.
    }
}