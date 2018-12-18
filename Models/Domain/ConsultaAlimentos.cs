using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiMarina.Models.Domain
{
    public class ConsultaAlimentos
    {
        public int id { get; set; }
        
        public virtual Consultas consulta { get; set; }

        public virtual IList<Alimentos> alimentos { get; set; }
    }
}
