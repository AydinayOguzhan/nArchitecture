using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        //Veritabanı objesi. Entity üzerinde default olarak tanımlanmış Id sütunu olduğu için bir daha tanımlamaya gerek yok.
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; } //Markanın birden çok modeli olacağı için Collection (Liste) olarak tanımlandı

        public Brand()
        {
        }

        public Brand(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}