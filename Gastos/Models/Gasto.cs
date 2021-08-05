using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    }
}
