using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class Gasto
    {
        [Key]
        public new int Id { get; set; }

        public string Tittle { get; set; }

        public double Valor { get; set; }

        public DateTime DateAdd  { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
