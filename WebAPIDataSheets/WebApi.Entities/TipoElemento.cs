using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    [Table("TipoElemento")]
    public class TipoElemento
    {
        [Key]
        public int TipoElementoId { get; set; }

        public string Nombre { get; set; }

        public int ClaseElementoId { get; set; }
        public ClaseElemento ClaseElemento { get; set; }

        public ICollection<Elemento> Elementos { get; set; }
    }
}
