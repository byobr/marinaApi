using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApiMarina.Models.Domain
{
    public class Clientes
    {

        public int id { get; set; }
        [Required]
        public string nome { get; set; }

        public DateTime dataNascimento { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string endereco { get; set; }

        public string telefoneResidencial { get; set; }

        public string telefoneComercial { get; set; }
        [Required]
        public string telefoneCelular { get; set; }
    }
}
