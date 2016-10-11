using System;
using Gtk;
using Org.InstitutoSerpis.Ad;

namespace PDbPrueba
{
	public partial class Window : Gtk.Window 
	{
		public Window () : base(Gtk.WindowType.Toplevel) {
			Build ();
			IconList list = new List<Articulo> ();
			list.Add (new Articulo

			TreeViewHelper.Fill (treeView, list);
		
//		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
//		TreeView.Model = listStore;
//		listStore.AppendValues (1L, "categoria 1", 1.5m);
//		listStore.AppendValues (2L, "categoria 2", 2.5m);

		}
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;
		
		}
	}
	public class Categoria {
		public long Id {get; set;}
		public string Nombre { get; set; }
	}
	public class Articulo{
		
	}
}