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
    [RoutePrefix("industria")]
    public class IndustriaController : BaseController
    {
        public IndustriaController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(IndustriaController)} en ejecución");
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
            return Ok(_unit.IndustriaRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.IndustriaRepository.Get(id));
        }

        //customer/ HTTPMETHOD: POST
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Industria industria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _unit.IndustriaRepository.Add(industria);
            _unit.Save();

            var id = _unit.IndustriaRepository.GetAll().LastOrDefault().IndustriaId;

            return Ok(new { id });
        }

        //customer/ HTTPMETHOD: PUT
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Industria industria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _unit.IndustriaRepository.Update(industria);
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
                _unit.IndustriaRepository.Delete(new Industria { IndustriaId = id });
                _unit.Save();
            }
            catch (Exception)
            {
                return BadRequest("Id incorrecto");
            }
            return Ok(new { delete = true });
        }

        //customer/list HTTPMETHOD: GET
        //[Route("list/{page}/{rows}")]
        //[HttpGet]
        //public IHttpActionResult GetList(int page, int rows)
        //{
        //    var startRecord = ((page - 1) * rows) + 1;
        //    var endRecord = page * rows;
        //    return Ok(_unit.Customers.PagedList(startRecord, endRecord));
        //}

        //[HttpGet]
        //[Route("count")]
        //public IHttpActionResult GetCount()
        //{
        //    return Ok(_unit.Customers.Count());
        //}
    }
}
