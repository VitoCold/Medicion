using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        IClaseElementoRepository ClaseElementoRepository { get;}
        IElementoRepository ElementoRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IIndustriaRepository IndustriaRepository { get; }
        ISedeRepository SedeRepository { get; }
        ITipoElementoRepository TipoElementoRepository { get; }
        ITuberiaRepository TuberiaRepository { get; }
        
        int Save();
    }
}
