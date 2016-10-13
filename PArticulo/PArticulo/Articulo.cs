using System;

namespace PArticulo
{
	public class Articulo{
		public Articulo (long id, string nombre, decimal precio, long categoria){
			Id = id;
			nombre = nombre;
			precio = precio;
			Categoria = categoria;
		}
		public long Id { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public long Categoria { get; set; }
	}
}