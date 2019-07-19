using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    [Table("Sede")]
    public class Sede
    {
        [Key]
        public int SedeId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Industria> Industrias { get; set; }
    }
}
