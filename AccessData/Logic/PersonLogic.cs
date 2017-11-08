using AccessData.DTO;
using AccessData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Logic
{
   public class PersonLogic
   {
        //get list to employees
        public List<PersonaDTO> GetEmpleados()
        {
            using (var contex = new EMPRESAEntities())
            {
                return contex.EMPLEADO.Select(x => new PersonaDTO()
                {
                    ID = x.ID,
                    NOMBRE = x.NOMBRE,
                    PRIMERAPELLIDO = x.PRIMERAPELLIDO,
                    SEGUNDOAPELLIDO = x.SEGUNDOAPELLIDO,
                    FECHAINGRESO = x.FECHAINGRESO,
                    EDAD = x.EDAD,
                    SALARIO = (Decimal)x.SALARIO,
                    CARGO = x.IDCARGO,
                    CIUDAD = x.IDCIUDAD
                }).ToList();
            }
        }

        // get employee by id 
        public  EMPLEADO GetEmpledoXId(int idEmployee)
        {
            using (var contex = new EMPRESAEntities())
            {
                return contex.EMPLEADO.
                       Where(x=> x.ID == idEmployee).FirstOrDefault();
            }
        }



        public  bool AgregarCliente(PersonaDTO empleado)
        {
            using (var contex = new EMPRESAEntities())
            {


                var person = new EMPLEADO
                {
                    NOMBRE = empleado.NOMBRE,
                    PRIMERAPELLIDO = empleado.PRIMERAPELLIDO,
                    SEGUNDOAPELLIDO = empleado.SEGUNDOAPELLIDO,
                    FECHAINGRESO = DateTime.Now,
                    EDAD = empleado.EDAD,
                    SALARIO = empleado.SALARIO,
                    IDCARGO = 1,
                    IDCIUDAD = 1
                };
                contex.EMPLEADO.Add(person);
                contex.SaveChanges();
                if (person.ID > 0)
                    return true;
                else
                    return false;
            }
        }


        public bool UpdateCliente(EMPLEADO empleado)
        {
            using (var contex = new EMPRESAEntities())
            {
             var Empleado  =  contex.EMPLEADO. Where(x => x.ID == empleado.ID).FirstOrDefault();
                Empleado = empleado;
                contex.SaveChanges();

                if (contex.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
 
        }


        public bool DeleteCliente(int idCliente )
        {

            using (var contex = new EMPRESAEntities())
            {
              var cliente = contex.EMPLEADO.Where(x => x.ID == idCliente).FirstOrDefault();
                contex.EMPLEADO.Remove(cliente);
                if (contex.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }


    }
}
