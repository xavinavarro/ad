using System;
using Gtk;

namespace PDbPrueba
{
	public partial class Window : Gtk.Window 
	{
		public Window () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
			treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
			ListStore listStore = new ListStore (typeof(long), typeof(string));
			treeView.Model = listStore;
			listStore.AppendValues (1L, "categoria 1");
		}
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;
		}
	}
}