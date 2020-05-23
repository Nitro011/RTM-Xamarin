using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTM.Models;
using RTM.Repository.Interface;

namespace RTM.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PPSandyController : ControllerBase
    {
        private readonly IGenericRepository<Almacen> _GenericRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public PPSandyController(IGenericRepository<Almacen> GenericRepository, IUnitOfWork UnitOfWork)
        {
            this._GenericRepository = GenericRepository;
            this._UnitOfWork = UnitOfWork;
        }

        // GET: api/PPSandy
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PPSandy/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PPSandy
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody] Almacen almacen)
        {
            try
            {
                await _GenericRepository.Add(almacen);
                _UnitOfWork.Commit();

                return Ok(new Request
                {
                    status = true,
                    message = "Se registro correctamente",
                    data = almacen

                });
            }
            catch (Exception ex)
            {

                return Ok(new Request
                {
                    status = false,
                    message = "No se registro correctamente",
                    data = ex.Message

                });
            }
        }

        // PUT: api/PPSandy/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
