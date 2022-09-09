using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>()
                .ForMember(c=>c.BrandName, opt=>opt.MapFrom(c=>c.Brand.Name)) //c'deki brandName'i opt.c'deki brand'in içindeki name'alanından al
                //Birden fazla eklenecekse fluent yapıda . (nokta) koyup ForMember diyerek yapabilirsin
                .ReverseMap(); 
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
