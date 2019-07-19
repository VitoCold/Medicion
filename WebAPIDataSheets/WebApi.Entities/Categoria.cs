using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }


        public ICollection<Industria> Industrias { get; set; }
    }
}
