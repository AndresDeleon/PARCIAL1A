using System;
using System.ComponentModel.DataAnnotations;

namespace PARCIAL1A.Models
{
    public class Platos
    {
        [Key]
		public int PlatoID { get; set; }
		public int EmpresaID { get; set; }
		public int GrupoID { get; set; }
		public string NombrePlato { get; set; }
		public string DescripcionPlato { get; set; }
		public decimal Precio { get; set; }
		public string TiempoPreparacion { get; set; }
		public string Imagen { get; set; }
		public string AplicaPropina { get; set; }
		public string Lunes { get; set; }
		public string Mates { get; set; }
		public string Miercoles { get; set; }
		public string Jueves { get; set; }
		public string Viernes { get; set; }
		public string Sabado { get; set; }
		public string Domingo { get; set; }
		public string Estado { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }

    }
}
