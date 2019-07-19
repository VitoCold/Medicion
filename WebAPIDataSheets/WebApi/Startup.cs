using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using WebApi.Entities;
using System.Web.Http;
using WebApi.Handlers;
using System.Web.Http.ExceptionHandling;
using WebApi.App_Start;
using Microsoft.Owin.Cors;

[assembly: OwinStartupAttribute(typeof(WebApi.Startup))]

namespace WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            log4net.Config.XmlConfigurator.Configure();
            var log = log4net.LogManager.GetLogger(typeof(Startup));
            log.Debug("Logging esta habilitado");

            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            DIConfig.ConfigureInjector(config);
           
            app.UseCors(CorsOptions.AllowAll);

            TokenConfig.ConfigureOAuth(app, config);
            RouteConfig.Register(config);
            WebApiConfig.Configure(config);
            app.UseWebApi(config);

            //Aquí ingreso datos si es que no existiesen
            CrearRolesyUsuarioAdmin();
            AgregarCategorias();
            AgregarSedes();
            AgregarTubos();
            AgregarEstados();
            AgregarClaseElementos();
        }
        private void CrearRolesyUsuarioAdmin()
        {
            var _appContext = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_appContext));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_appContext));

            //Creo el rol Administrador e ingreso el primer usuario administrador
            if (!roleManager.RoleExists("Administrador"))
            {
                // first we create Admin rool    
                var role = new IdentityRole
                {
                    Name = "Administrador"
                };

                roleManager.Create(role);

                //var _UserName = "administrador";

                var _Email = "administrador@contugas.com.pe";

                string userPWD = "Ctg2019.Admin";

                var user = new ApplicationUser { UserName = _Email, Email = _Email };
                var result = UserManager.Create(user, userPWD);
                
                if (result.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Administrador");

                }
            }

        }

        private void AgregarCategorias()
        {
            IUnitOfWork _context = new UnitOfWork();
            var categorias = _context.CategoriaRepository.GetAll().ToList();

            if (!categorias.Exists(q=>q.Nombre=="GNV"))
            {
                var categoria = new Categoria
                {
                    Nombre = "GNV"
                };
                _context.CategoriaRepository.Add(categoria);
                _context.Save();

            }

            if (!categorias.Exists(q => q.Nombre == "GNC"))
            {
                var categoria = new Categoria
                {
                    Nombre = "GNC"
                };
                _context.CategoriaRepository.Add(categoria);
                _context.Save();

            }

            if (!categorias.Exists(q => q.Nombre == "Generadora"))
            {
                var categoria = new Categoria
                {
                    Nombre = "Generadora"
                };
                _context.CategoriaRepository.Add(categoria);
                _context.Save();

            }

            if (!categorias.Exists(q => q.Nombre == "Pesquera"))
            {
                var categoria = new Categoria
                {
                    Nombre = "Pesquera"
                };
                _context.CategoriaRepository.Add(categoria);
                _context.Save();

            }

            if (!categorias.Exists(q => q.Nombre == "Industrial"))
            {
                var categoria = new Categoria
                {
                    Nombre = "Industrial"
                };
                _context.CategoriaRepository.Add(categoria);
                _context.Save();

            }

        }

        private void AgregarSedes()
        {
            IUnitOfWork _context = new UnitOfWork();
            var sedes = _context.SedeRepository.GetAll().ToList();

            if (!sedes.Exists(q => q.Nombre == "Pisco"))
            {
                var pisco = new Sede
                {
                    Nombre = "Pisco"
                };
                _context.SedeRepository.Add(pisco);
                _context.Save();

            }

            if (!sedes.Exists(q => q.Nombre == "Chincha"))
            {
                var chincha = new Sede
                {
                    Nombre = "Chincha"
                };
                _context.SedeRepository.Add(chincha);
                _context.Save();

            }

            if (!sedes.Exists(q => q.Nombre == "Ica"))
            {
                var sede = new Sede
                {
                    Nombre = "Ica"
                };
                _context.SedeRepository.Add(sede);
                _context.Save();

            }

            if (!sedes.Exists(q => q.Nombre == "Nasca"))
            {
                var sede = new Sede
                {
                    Nombre = "Nasca"
                };
                _context.SedeRepository.Add(sede);
                _context.Save();

            }

            if (!sedes.Exists(q => q.Nombre == "Marcona"))
            {
                var sede = new Sede
                {
                    Nombre = "Marcona"
                };
                _context.SedeRepository.Add(sede);
                _context.Save();

            }

        }

        private void AgregarTubos()
        {
            IUnitOfWork _context = new UnitOfWork();
            var tubos = _context.TuberiaRepository.GetAll().ToList();

            if (!tubos.Exists(q => q.Nombre =="Acero"))
            {
                var tubo = new Tuberia
                {
                    Nombre = "Acero"
                };
                _context.TuberiaRepository.Add(tubo);
                _context.Save();

            }

            if (!tubos.Exists(q => q.Nombre =="Polietileno"))
            {
                var tubo = new Tuberia
                {
                    Nombre = "Polietileno"
                };
                _context.TuberiaRepository.Add(tubo);
                _context.Save();

            }


        }

        private void AgregarEstados()
        {
            IUnitOfWork _context = new UnitOfWork();
            var estados = _context.EstadoRepository.GetAll().ToList();

            if (!estados.Exists(q => q.Nombre == "Activo"))
            {
                var estado = new Estado
                {
                    Nombre = "Activo"
                };
                _context.EstadoRepository.Add(estado);
                _context.Save();

            }
            if (!estados.Exists(q => q.Nombre == "Inactivo"))
            {
                var estado = new Estado
                {
                    Nombre = "Inactivo"
                };
                _context.EstadoRepository.Add(estado);
                _context.Save();

            }


        }

        private void AgregarClaseElementos()
        {
            IUnitOfWork _context = new UnitOfWork();
            var clases = _context.ClaseElementoRepository.GetAll().ToList();

            if (!clases.Exists(q => q.Nombre == "Primario"))
            {
                var clase = new ClaseElemento
                {
                    Nombre = "Primario"
                };
                _context.ClaseElementoRepository.Add(clase);
                _context.Save();

            }
            if (!clases.Exists(q => q.Nombre == "Secundario"))
            {
                var clase = new ClaseElemento
                {
                    Nombre = "Secundario"
                };
                _context.ClaseElementoRepository.Add(clase);
                _context.Save();

            }

            if (!clases.Exists(q => q.Nombre == "Terciario"))
            {
                var clase = new ClaseElemento
                {
                    Nombre = "Terciario"
                };
                _context.ClaseElementoRepository.Add(clase);
                _context.Save();

            }


        }

    }
}
