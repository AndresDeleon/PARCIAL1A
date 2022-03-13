using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PARCIAL1A.Models
{
    public class ElementosPorPlato
    {
        [Key]
        public int ElementoPorPlatoID { get; set; }
        public int EmpresaID { get; set; }
        public int PlatoID { get; set; }
        public int ElementoID { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
