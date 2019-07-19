using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
   public class WebApiDbContext:DbContext
    {
        public WebApiDbContext():base("WepApiCnx")
        {

        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tuberia> Tuberias { get; set; }
        public DbSet<ClaseElemento> ClaseElementos { get; set; }
        public DbSet<TipoElemento> TipoElementos { get; set; }
        public DbSet<Industria> Industrias { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
    }
}
