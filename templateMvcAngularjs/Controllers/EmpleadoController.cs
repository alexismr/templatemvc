using AccessData.DTO;
using AccessData.Entity;
using AccessData.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace templateMvcAngularjs.Controllers
{
    public class EmpleadoController : ApiController
    {
        // GET: api/Empleado
        public IEnumerable<PersonaDTO> GetEmpleados()
        {

            try
            {
                var clientes = new PersonLogic();
                return clientes.GetEmpleados();
            }
            catch (Exception ex)
            {
                var mensaje = ex;
                throw;
            }


        }

        // GET: api/Empleado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empleado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
        }
    }
}
