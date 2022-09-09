using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        //Veritabanı bağlantısı için kullanılacak repository. Base Repositary class'ında default olarak tanımlanmış metotlar bulunmakta. 
        //Default metotların dışında metot tanımlanmak istenirse burada tanımlanır.
        public ModelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}