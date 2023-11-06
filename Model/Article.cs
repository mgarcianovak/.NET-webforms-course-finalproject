using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {   
        public Article()
        {
            Brand = new Brand();
            Category = new Category();
        }

        public int Id { get; set; }

        [DisplayName("Código")]
        public string Code { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Marca")]
        public Brand Brand { get; set; }

        [DisplayName("Categoría")]
        public Category Category { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Precio")]
        public Decimal Price { get; set; }
    }
}
