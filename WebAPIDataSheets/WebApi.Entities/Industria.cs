using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    [Table("Industria")]
    public class Industria
    {
        [Key]
        public int IndustriaId { get; set; }
        public string Tag { get; set; }
        public string Nombre { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int SedeId { get; set; }
        public Sede Sede { get; set; }

        public int TuberiaId { get; set; }
        public Tuberia Tuberia { get; set; }

        public ICollection<Elemento> Elementos { get; set; }

    }
}
