using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webApiMarina.Models.Domain
{
    public class Consultas
    {

        public int id { get; set; }
        public virtual Clientes cliente { get; set; }
        public DateTime dataHora { get; set; }
        [Required]
        public double peso { get; set; }
        [Required]
        public double porcentualGordura { get; set; }
        [MaxLength(150)]
        public string sensacaoFisica { get; set; }
        public string restricoesAlimentares { get; set; }
        [Required]
        public int metaCalorias { get; set; }
        [Required]
        public virtual IList<ConsultaAlimentos> consultaAlimentos { get; set; }

    }
}
