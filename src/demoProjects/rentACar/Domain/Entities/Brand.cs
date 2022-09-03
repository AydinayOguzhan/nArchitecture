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