using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    [Table("Estado")]
   public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Elemento> Elementos { get; set; }
    }
}
