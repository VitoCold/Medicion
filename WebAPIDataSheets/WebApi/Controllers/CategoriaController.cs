using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("categoria")]
    public class CategoriaController : BaseController
    {
        public CategoriaController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(CategoriaController)} en ejecución");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("error")]
        public IHttpActionResult CreateError()
        {
            throw new System.Exception("Este es un error no manejado");
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult Index()
        {
            return Ok(_unit.CategoriaRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.CategoriaRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Categoria categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.CategoriaRepository.Add(categoria);
            _unit.Save();

            var id = _unit.CategoriaRepository.GetAll().LastOrDefault().CategoriaId;

            return Ok(new { id });
        }


        //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Categoria categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.CategoriaRepository.Update(categoria);
                _unit.Save();

            }
            catch (Exception)
            {

                return BadRequest("Id incorrecto");
            }

            return Ok(new { status = true });
        }

        //customer/1 HTTPMETHOD: DELETE
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            try
            {
                _unit.CategoriaRepository.Delete(new Categoria { CategoriaId = id });
                _unit.Save();
            }
            catch (Exception)
            {
                return BadRequest("Id incorrecto");
            }
            return Ok(new { delete = true });
        }
    }
}
