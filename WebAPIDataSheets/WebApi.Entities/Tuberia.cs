using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    [Table("Tuberia")]
    public class Tuberia
    {
        [Key]
        public int TuberiaId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Industria> Industrias { get; set; }
    }
}
