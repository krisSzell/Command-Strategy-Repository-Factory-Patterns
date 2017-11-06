using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CarWashServiceBrowserFull.API;
using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserFull.API.Repositories;

namespace CarWashServiceBrowserFull.API.Controllers.api
{
    public class ServicesController : ApiController
    {
        private IServicesRepository _repo;

        public ServicesController()
        {
            _repo = new SqlServicesRepository();
        }

        // GET: api/Services
        public async Task<IHttpActionResult> GetServices()
        {
            var services = await _repo.GetAllAsync();
            return Ok(services);
        }
        
        // GET: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> GetService(int id)
        {
            Service service = await _repo.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutService(int id, Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.ServiceId)
            {
                return BadRequest();
            }

            _repo.Update(id, service);

            try
            {
                await _repo.PersistChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repo.ServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Services
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> PostService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(service);
            await _repo.PersistChangesAsync();

            return Created("api/services", service);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> DeleteService(int id)
        {
            Service service = await _repo.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _repo.Remove(service);
            await _repo.PersistChangesAsync();

            return Ok(service);
        }


        
    }
}