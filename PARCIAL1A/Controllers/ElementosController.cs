using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;
using System.Collections.Generic;
using System.Linq;

namespace PARCIAL1A.Controllers
{
    [ApiController]
    public class ElementosController : ControllerBase
    {
        private readonly ordenContext _contexto;

        public ElementosController(ordenContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/ElementosPorPlato/{nombrePlato}")]
        public IActionResult Get(string nombrePlato)
        {

            var elementos = (from epp in _contexto.ElementosPorPlato
                            join e in _contexto.Elementos on epp.ElementoID equals e.ElementoID
                            join p in _contexto.Platos on epp.PlatoID equals p.PlatoID
                            where p.NombrePlato == nombrePlato
                            select new
                                    {
                                        e.Elemento
                                    });


            if (elementos.Count() > 0)
            {
                return Ok(elementos);
            }
            return NotFound();
        }
    }
}
