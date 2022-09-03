using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListBrand
{
    //Veri sayfalı olarak geleceği için BrandListModel dedik. Dto demedik çünkü bu birden fazla verinin birleşmesi (join) değil. İçinde sayfalama bilgisi gibi
    //başka bilgiler olacağı için model dedik. (Dto veritabanından gelen verinin görünümü)
    //Query'ler select query'leri tutmak içindir.
    public class GetListBrandQuery: IRequest<BrandListModel>
    {
        //Kaçıncı sayfayı ve bir sayfada kaç tane data olduğunu kullanıcıdan almak için bu parametreyi ekledik.
        //Command'lerde olduğu gibi kullanıcıdan alınacak parametreler burada tanımlanıyor.
        public PageRequest PageRequest { get; set; }

        //Handler metodunu elle yazdık ancak içindeki handle metodu otomatik olarak IRequestHandler'dan geliyor.
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize);
                BrandListModel mappedBrandListModel = _mapper.Map<BrandListModel>(brands);
                return mappedBrandListModel;
            }
        }
    }
}
