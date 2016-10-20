using System;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			spinButtonPrecio.Value = 0;
			saveAction.Sensitive = false;
			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");
			};
			entryNombre.Changed += delegate{
				string content = entryNombre.Text.Trim();
				saveAction.Activated = !content.Equals("");
			};
		}
	}
	public class Categoria{
		public Categoria (long id, string nombre){
			Id = id;
			Nombre = nombre;
		}
		public long Id { get; set;}
		public string Nombre { get; set;}
	}
}