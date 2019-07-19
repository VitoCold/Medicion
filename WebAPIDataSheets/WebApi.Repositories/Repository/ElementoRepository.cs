using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class ElementoRepository : GenericRepository<Elemento, WebApiDbContext>, IElementoRepository
    {
        public ElementoRepository(WebApiDbContext context)
        {
            this.EFContext = context;
        }
    }
}
