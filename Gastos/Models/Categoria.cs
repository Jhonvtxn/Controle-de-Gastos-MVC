using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class Categoria
    {
        [Key]
        public new int IdCategory { get; set; }

        public string Name { get; set; }
        
        [NotMapped]
        public double ValorCategoria { get; set; }
    }
}
