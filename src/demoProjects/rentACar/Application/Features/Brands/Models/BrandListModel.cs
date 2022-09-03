using Application.Features.Brands.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Models
{
    //BasePageableModel sayfalama bilgilerini içeriyor. Bu class aslında içinde veritabanı görünümü (dto) ve aynı zamanda sayfalama bilgilerini barındıran bir model.
    public class BrandListModel: BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
