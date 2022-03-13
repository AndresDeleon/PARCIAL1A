using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL1A.Controllers
{
    [ApiController]
    public class PlatosPorComboController:ControllerBase
    {
        private readonly ordenContext _contexto;

        public PlatosPorComboController(ordenContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL
        [HttpGet]
        [Route("api/PlatosPorCombo")]
        public IActionResult Get()
        {
            var ppcbList = from ppc in _contexto.PlatosPorCombo
                           join c in _contexto.Platos on ppc.PlatoID equals c.PlatoID
                           select new
                            {
                               ppc.PlatosPorComboID,
                               ppc.EmpresaID,
                               ppc.ComboID,
                               c.NombrePlato,
                               ppc.Estado,
                               ppc.FechaCreacion,
                               ppc.FechaModificacion
                            };

            if (ppcbList.Count()>0)
            {
                return Ok(ppcbList);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/PlatosPorCombo/{id}")]
        public IActionResult Get(int id)
        {

            PlatosPorCombo ppcList = (from ppc in _contexto.PlatosPorCombo 
                                      where ppc.PlatosPorComboID==id select ppc).FirstOrDefault();

            if (ppcList!=null)
            {
                return Ok(ppcList);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/PlatosPorCombo/")]
        public IActionResult agregarPlatosPorCombo([FromBody] PlatosPorCombo ppcNew)
        {

            _contexto.PlatosPorCombo.Add(ppcNew);
            _contexto.SaveChanges();

            return Ok(ppcNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/PlatosPorCombo/")]
        public IActionResult editarPlatosPorCombo([FromBody] PlatosPorCombo ppcUpdate)
        {

            PlatosPorCombo ppcExist = (from ppc in _contexto.PlatosPorCombo
                                  where ppc.PlatosPorComboID==ppcUpdate.PlatosPorComboID
                                  select ppc).FirstOrDefault();

            if (ppcExist is null)
            {
                return NotFound();
            }

            ppcExist.EmpresaID=ppcUpdate.EmpresaID;
            ppcExist.ComboID=ppcUpdate.ComboID;
            ppcExist.PlatoID=ppcUpdate.PlatoID;
            ppcExist.Estado=ppcUpdate.Estado;
            ppcExist.FechaCreacion=ppcUpdate.FechaCreacion;
            ppcExist.FechaModificacion=ppcUpdate.FechaModificacion;

            _contexto.Entry(ppcExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(ppcExist);
        }

    }
}
