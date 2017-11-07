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
using AccessData.Entity;

namespace templateMvcAngularjs.Controllers
{
    public class EMPLEADOesController : ApiController
    {
        private EMPRESAEntities db = new EMPRESAEntities();

        // GET: api/EMPLEADOes
        public IQueryable<EMPLEADO> GetEMPLEADO()
        {
            return db.EMPLEADO;
        }

        // GET: api/EMPLEADOes/5
        [ResponseType(typeof(EMPLEADO))]
        public async Task<IHttpActionResult> GetEMPLEADO(int id)
        {
            EMPLEADO eMPLEADO = await db.EMPLEADO.FindAsync(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO);
        }

        // PUT: api/EMPLEADOes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEMPLEADO(int id, EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADO.ID)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADOExists(id))
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

        // POST: api/EMPLEADOes
        [ResponseType(typeof(EMPLEADO))]
        public async Task<IHttpActionResult> PostEMPLEADO(EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLEADO.Add(eMPLEADO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eMPLEADO.ID }, eMPLEADO);
        }

        // DELETE: api/EMPLEADOes/5
        [ResponseType(typeof(EMPLEADO))]
        public async Task<IHttpActionResult> DeleteEMPLEADO(int id)
        {
            EMPLEADO eMPLEADO = await db.EMPLEADO.FindAsync(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            db.EMPLEADO.Remove(eMPLEADO);
            await db.SaveChangesAsync();

            return Ok(eMPLEADO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADOExists(int id)
        {
            return db.EMPLEADO.Count(e => e.ID == id) > 0;
        }
    }
}