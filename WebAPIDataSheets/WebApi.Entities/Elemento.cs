using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    [Table("Elemento")]
    public class Elemento
    {
        [Key]
        public int ElementoId { get; set; }
        public string Nombre { get; set; }
        
        public int IndustriaId { get; set; }
        public Industria Industria { get; set; }

        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public int TipoElementoId { get; set; }
        public TipoElemento TipoElemento { get; set; }
    }
}
