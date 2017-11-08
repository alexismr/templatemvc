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
    [RoutePrefix("api/Empleado")]
    public class EmpleadoController : ApiController
    {
        private PersonLogic _clientes = new PersonLogic();
        // GET: api/Empleado
        public IEnumerable<PersonaDTO> GetEmpleados()
        {
            try
            {
               
                return _clientes.GetEmpleados();
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
        [Route("addEmpleado")]
        [AcceptVerbs("POST")]
        public Boolean addempledo([FromBody]PersonaDTO persona)
        {
            var response = _clientes.AgregarCliente(persona);
            return response;

        }

        // PUT: api/Empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("DeleteEmpleado/{id}")]
        [AcceptVerbs("POST", "DELETE")]
        // DELETE: api/Empleado/5
        public bool Delete(int id)
        {
            var response = _clientes.DeleteCliente(id);
            return response;
        }
    }
}
