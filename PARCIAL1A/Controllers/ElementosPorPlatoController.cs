using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ElementosPorPlatoController : ControllerBase
    {
        private readonly ordenContext _contexto;
        public ElementosPorPlatoController(ordenContext micontexto)
        {
            _contexto = micontexto;
        }
        [HttpGet]
        [Route("api/ConsultarElemtosporPlatos")]
        public IActionResult Get()
        {

            var listaElemtospp = (from e in _contexto.ElementosPorPlato
                                  
                             //  join Fid in _contexto.Elemento on e.ElementoID equals Fid.id
                               //join Pid in _contexto.Platos on e.PlatoID equals Pid.id
                                  select new
                               {
                                   e.ElementoPorPlatoID,
                                   e.EmpresaID,
                                   //  PlatoID= Pid.PlatoID
                                   e.PlatoID,
                                   e.ElementoID,
                                   e.Cantidad,
                                   e.Estado,
                                   e.FechaCreacion,
                                   e.FechaModificacion
                                 
                                 

                               });

            if (listaElemtospp.Count() > 0)
            {
                return Ok(listaElemtospp);
            }
            return NotFound();

        }

       


        [HttpPost]
        [Route("api/InsertarElementoporPlato")]
        public IActionResult guardarElemtopp([FromBody] ElementosPorPlato ElementoPPNuevo)
        {
            try
            {
                _contexto.ElementosPorPlato.Add(ElementoPPNuevo);
                _contexto.SaveChanges();
                return Ok(ElementoPPNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route ("api/EliminarElementoPorPlato/{ElementoPorPlatoID}")]
        public IActionResult Get(int ElementoPorPlatoID)

        {

            try
            {


                var ElementoAEliminar = (from e in _contexto.ElementosPorPlato
                                         where e.ElementoPorPlatoID == ElementoPorPlatoID
                                         select new
                                         {
                                             e.ElementoPorPlatoID
                                         });


                if (ElementoAEliminar != null)
                {
                    return (IActionResult)_contexto.ElementosPorPlato.Remove((ElementosPorPlato)ElementoAEliminar);

                }

                //return (IActionResult)_contexto.Remove(ElementoAEliminar);
                return NotFound($"Elemento por plato con Id = {ElementoPorPlatoID} not found");


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

       

        [HttpPut]
        [Route("api/ActualizarElementoPorPlato")]
        public IActionResult updateElementoporPlato([FromBody] ElementosPorPlato ElementoPPAModificar)
        {

            //Para actualizar un registro, se obtiene el registro origial de la base de datos
            ElementosPorPlato ElementoPorPlatoExiste = (from e in _contexto.ElementosPorPlato
                                                        where e.ElementoPorPlatoID == ElementoPPAModificar.ElementoPorPlatoID
                                                        select e).FirstOrDefault();
            if (ElementoPorPlatoExiste is null)
            {
                // si no existe el registro de retorna un NO ENCONTRAD

                return NotFound();
            }

            // si se encuntra el registro, se alteran los campos a modi ficar.
            ElementoPorPlatoExiste.EmpresaID = ElementoPPAModificar.EmpresaID;
            ElementoPorPlatoExiste.PlatoID = ElementoPPAModificar.PlatoID;
            ElementoPorPlatoExiste.ElementoID = ElementoPPAModificar.ElementoID;
            ElementoPorPlatoExiste.Cantidad= ElementoPPAModificar.Cantidad;
            ElementoPorPlatoExiste.Estado = ElementoPPAModificar.Estado;
            ElementoPorPlatoExiste.FechaCreacion = ElementoPPAModificar.FechaCreacion;
            ElementoPorPlatoExiste.FechaModificacion = ElementoPPAModificar.FechaModificacion;


            //Se envia el objeto a la base de datos.
            _contexto.Entry(ElementoPorPlatoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(ElementoPorPlatoExiste);
        }
    }
}
