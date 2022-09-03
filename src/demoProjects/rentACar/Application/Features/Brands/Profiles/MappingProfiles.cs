using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    //Buraya map'leme profilleri yazılır. Alan isimleri aynı olduğu zaman default olarak map edilir ancak olmaması durumları için yazıyoruz. 
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Hangi objenin hangi objeye çevirileceğini belirlemek için oluşturuyoruz. ReverseMap() metodu tersinin de çalışması için ekleniyor. 
            //Objelerin property isimlerini birbirleriyle aynı/uyumlu verdiğimiz için ekstra bir konfigürasyon yapmamıza gerek kalmıyor.
            CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
        }
    }
}
