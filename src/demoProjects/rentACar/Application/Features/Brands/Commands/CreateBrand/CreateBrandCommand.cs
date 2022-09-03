using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        //Command için gerekli property'ler
        public string Name { get; set; }

        //Command'in işlemlerini yapacak handler. Başka bir dosyada olması veya olmaması arasında bir fark yok ancak biri olmadan diğeri olmaz.
        //Madiator Command'i çalıştırmak için kendi listesinden gerekli handler'ı bulup onu çalıştırıyor.
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            //Constructor Injection
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                //Business Rulse bu şekilde kullanılır. Birden fazla olması durumunda alt alta eklenir ve o şekilde kullanılır. 
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                //Command bir request olarak geldi ve gelen command'i mapleyerek brand nesnesine çevirdik.
                Brand mappedBrand = _mapper.Map<Brand>(request);
                //Oluşturulan brand nesnesini veritabanına kaydettik ve gelen responsu brand nesnesi olarak aldık.
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
                //Veritabanı objesini direkt olarak return etmemek için gelen nesneyi oluşturduğumuz dto'ya mapledik ve return ettik. Bunda defensive programlama deniyor.
                //Kullanıcıya gösterilmek istenmeyen alanları göstermemek için oluşturulmuş dto kullanıcıya dönülür. 
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);
                return createdBrandDto;
            }
        }
    }
}
