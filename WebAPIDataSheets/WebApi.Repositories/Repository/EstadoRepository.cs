﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class EstadoRepository : GenericRepository<Estado, WebApiDbContext>, IEstadoRepository
    {
        public EstadoRepository(WebApiDbContext context)
        {
            this.EFContext = context;
        }
    }
}
