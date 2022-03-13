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
    public class PlatosController : ControllerBase
    {
        private readonly ordenContext _contexto;
        public PlatosController(ordenContext micontexto)
        {
            _contexto = micontexto;
        }
        [HttpGet]
        [Route("api/ConsultarPlatos")]
        public IActionResult Get()
        {

            var listaPlatos = (from e in _contexto.Platos

                                  select new
                                  {
                                      e.PlatoID,
                                      e.EmpresaID,
                                      e.GrupoID,
                                      e.NombrePlato,
                                      e.DescripcionPlato,
                                      e.Precio,
                                      e.TiempoPreparacion,
                                      e.Imagen,
                                      e.AplicaPropina,
                                      e.Lunes,
                                      e.Mates,
                                      e.Miercoles,
                                      e.Jueves,
                                      e.Viernes,
                                      e.Sabado,
                                      e.Domingo,
                                      e.Estado,
                                      e.FechaCreacion,
                                      e.FechaModificacion 

    });

            if (listaPlatos.Count() > 0)
            {
                return Ok(listaPlatos);
            }
            return NotFound();

        }




        [HttpPost]
        [Route("api/InsertarPlato")]
        public IActionResult guardarPlato([FromBody] Platos PlatoNuevo)
        {
            try
            {
                _contexto.Platos.Add(PlatoNuevo);
                _contexto.SaveChanges();
                return Ok(PlatoNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("api/EliminarPlato/{PlatoID}")]
        public IActionResult Get(int PlatoID)

        {

            try
            {


                var PlatoAEliminar = (from e in _contexto.Platos
                                         where e.PlatoID == PlatoID
                                         select new
                                         {
                                             e.PlatoID
                                         });


                if (PlatoAEliminar != null)
                {
                    return (IActionResult)_contexto.Platos.Remove((Platos)PlatoAEliminar);

                }

                //return (IActionResult)_contexto.Remove(ElementoAEliminar);
                return NotFound($"plato con Id = {PlatoID} not found");


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }



        [HttpPut]
        [Route("api/ActualizarPlato")]
        public IActionResult updatePlato([FromBody] Platos PlatoModificar)
        {

            //Para actualizar un registro, se obtiene el registro origial de la base de datos
            Platos PlatoExiste = (from e in _contexto.Platos
                                                        where e.PlatoID == PlatoModificar.PlatoID
                                                        select e).FirstOrDefault();
            if (PlatoExiste is null)
            {
                // si no existe el registro de retorna un NO ENCONTRAD

                return NotFound();
            }

            // si se encuntra el registro, se alteran los campos a modi ficar.

            PlatoExiste.PlatoID = PlatoModificar.PlatoID;
            PlatoExiste.EmpresaID = PlatoModificar.EmpresaID;
            PlatoExiste.GrupoID = PlatoModificar.GrupoID;
            PlatoExiste.NombrePlato = PlatoModificar.NombrePlato;
            PlatoExiste.DescripcionPlato = PlatoModificar.DescripcionPlato;
            PlatoExiste.Precio = PlatoModificar.Precio;
            PlatoExiste.TiempoPreparacion = PlatoModificar.TiempoPreparacion;
            PlatoExiste.Imagen = PlatoModificar.Imagen;
            PlatoExiste.AplicaPropina = PlatoModificar.AplicaPropina;
            PlatoExiste.Lunes = PlatoModificar.Mates;
            PlatoExiste.Miercoles = PlatoModificar.Miercoles;
            PlatoExiste.Jueves = PlatoModificar.Jueves;
            PlatoExiste.Viernes = PlatoModificar.Viernes;
            PlatoExiste.Sabado = PlatoModificar.Sabado;
            PlatoExiste.Domingo = PlatoModificar.Domingo;
            PlatoExiste.Estado = PlatoModificar.Estado;
            PlatoExiste.FechaCreacion = PlatoModificar.FechaCreacion;
            PlatoExiste.FechaModificacion = PlatoModificar.FechaModificacion;

            //Se envia el objeto a la base de datos.
            _contexto.Entry(PlatoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(PlatoExiste);
        }
    }
}
