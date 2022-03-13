using System;
using System.ComponentModel.DataAnnotations;

namespace PARCIAL1A.Models
{
    public class CompraElementos
    {
		[Key]
		public int CompraID { get; set; }
		public int EmpresaID { get; set; }
		public DateTime FechaCompra { get; set; }
		public int ElementoID { get; set; }
		public int Cantidad { get; set; }
		public string Estado { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
	}
}
