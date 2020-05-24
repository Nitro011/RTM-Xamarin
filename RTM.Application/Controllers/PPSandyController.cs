using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var search = await _UnitOfWork.context.almacens.ToListAsync();

                return Ok(new Request
                {
                    status = true,
                    message = "Se registro correctamente",
                    data = search

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

        // GET: api/PPSandy/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
               var search = await _UnitOfWork.context.almacens.FindAsync(id);

                return Ok(new Request
                {
                    status = true,
                    message = "Se registro correctamente",
                    data = search

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
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put([FromBody] Almacen almacen)
        {
            try
            {
                await _GenericRepository.Update(almacen);
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
