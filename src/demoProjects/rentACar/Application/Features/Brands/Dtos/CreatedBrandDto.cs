using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos
{
    //Veritabanı objesini direkt olarak kullananlara sunmamak için oluşturulmuş dto objesi.
    public class CreatedBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
