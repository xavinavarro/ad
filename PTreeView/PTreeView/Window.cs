using System;
using Gtk;
using Org.InstitutoSerpis.Ad;

namespace PDbPrueba
{
	public partial class Window : Gtk.Window 
	{
		public Window () : base(Gtk.WindowType.Toplevel) {
			Build ();
			string[] columnNames = {"id", "nombre", "precio"};
			TreeViewHelper.AppendColumns(treeView, columnNames);

			/*
			for (int index = 0; index < columnNames.Length; index++)

				treeView.AppendColumn (columnNames[index], new CellRendererText (),
				    delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
						CellRendererText cellRendererText = (CellRendererText)cell;
						object value = tree_model.GetValue(iter,column);
						cellRendererText.Text = value.ToString();
					Console.WriteLine ("index={0} column{1}", index, column);
					}
				);
				
		*/
		
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
		TreeView.Model = listStore;
		listStore.AppendValues (1L, "categoria 1", 1.5m);
		listStore.AppendValues (2L, "categoria 2", 2.5m);

		}
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;
		
		}
	}
}