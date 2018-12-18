using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApiMarina.Models.Domain
{
    public class Alimentos
    {
        public int id { get; set; }
        [MaxLength(120)]
        [Required]
        public string nome { get; set; }
        [Required]
        public int calorias { get; set; }
        [Required]
        public CategoriaAlimentos categoria { get; set; }
    }
}
