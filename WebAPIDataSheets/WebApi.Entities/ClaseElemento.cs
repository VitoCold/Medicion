using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    [Table("ClaseElemento")]
    public class ClaseElemento
    {
        [Key]
        public int ClaseElementoId { get; set; }
        public string Nombre { get; set; }

        public ICollection<TipoElemento> TipoElementos { get; set; }
    }
}
