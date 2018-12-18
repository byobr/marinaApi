using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApiMarina.Models.Domain
{
    public class CategoriaAlimentos
    {
        public int id { get; set; }
        [Required]
        public string nomeCategoria { get; set; }
    }
}
