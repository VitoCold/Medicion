using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiDbContext EFContext;

        public UnitOfWork()
        {
            this.EFContext = new WebApiDbContext();

            CategoriaRepository = new CategoriaRepository(EFContext);
            ClaseElementoRepository = new ClaseElementoRepository(EFContext);
            ElementoRepository = new ElementoRepository(EFContext);
            EstadoRepository = new EstadoRepository(EFContext);
            IndustriaRepository = new IndustriaRepository(EFContext);
            SedeRepository = new SedeRepository(EFContext);
            TipoElementoRepository = new TipoElementoRepository(EFContext);
            TuberiaRepository = new TuberiaRepository(EFContext);
        }

        public ICategoriaRepository CategoriaRepository { get; private set; }

        public IClaseElementoRepository ClaseElementoRepository { get; private set; }

        public IElementoRepository ElementoRepository { get; private set; }

        public IEstadoRepository EstadoRepository { get; private set; }

        public IIndustriaRepository IndustriaRepository { get; private set; }

        public ISedeRepository SedeRepository { get; private set; }

        public ITipoElementoRepository TipoElementoRepository { get; private set; }

        public ITuberiaRepository TuberiaRepository { get; private set; }

        public int Save()
        {
            try
            {
                return this.EFContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
