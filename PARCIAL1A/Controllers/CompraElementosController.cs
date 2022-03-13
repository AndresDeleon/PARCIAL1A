using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL1A.Controllers
{
    public class CompraElementosController : ControllerBase
    {

        private readonly ordenContext _contexto;

        public CompraElementosController(ordenContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL
        [HttpGet]
        [Route("api/CompraElementos")]
        public IActionResult Get()
        {
            var ceList = from ce in _contexto.CompraElementos
                           select new
                           {
                               ce.CompraID,
                               ce.EmpresaID,
                               ce.FechaCompra,
                               ce.ElementoID,
                               ce.Cantidad,
                               ce.Estado,
                               ce.FechaCreacion,
                               ce.FechaModificacion
                           };

            if (ceList.Count()>0)
            {
                return Ok(ceList);
            }

            return NotFound();
        }


        //CONSULTA FILTRADA
        [HttpGet]
        [Route("api/CompraElementos/{id}")]
        public IActionResult Get(int id)
        {

            CompraElementos ceList = (from ce in _contexto.CompraElementos
                                      where ce.CompraID==id
                                      select ce).FirstOrDefault();

            if (ceList!=null)
            {
                return Ok(ceList);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO
        [HttpPost]
        [Route("api/CompraElementos/")]
        public IActionResult agregarCompraElementos([FromBody] CompraElementos ceNew)
        {
            _contexto.CompraElementos.Add(ceNew);
            _contexto.SaveChanges();

            return Ok(ceNew);
        }


        //EDITAR EQUIPO
        [HttpPut]
        [Route("api/CompraElementos/")]
        public IActionResult editarCompraElementos([FromBody] CompraElementos ceUpdate)
        {

            CompraElementos ceExist = (from ce in _contexto.CompraElementos
                                        where ce.CompraID==ceUpdate.CompraID
                                       select ce).FirstOrDefault();

            if (ceExist is null)
            {
                return NotFound();
            }

            ceExist.EmpresaID=ceUpdate.EmpresaID;
            ceExist.FechaCompra=ceUpdate.FechaCompra;
            ceExist.ElementoID=ceUpdate.ElementoID;
            ceExist.Cantidad=ceUpdate.Cantidad;
            ceExist.Estado=ceUpdate.Estado;
            ceExist.FechaCreacion=ceUpdate.FechaCreacion;
            ceExist.FechaModificacion=ceUpdate.FechaModificacion;

            _contexto.Entry(ceExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(ceExist);
        }


    }
}
