using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
		);
		App.Instance.DbConnection.Open ();

		fill ();

		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};

		newAction.Activated += delegate {
			new ArticuloView();
		};

		editAction.Activated += delegate {
			Articulo articulo = ArticuloDao.Load(TreeViewHelper.GetId(treeView));
	};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
				ArticuloDao.Delete(TreeViewHelper.GetId(treeView));
		};


		refreshAction.Activated += delegate {
			fill();
		};
		//EntityDao.GetList<Articulo> ();

	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		IList list = ArticuloDao.GetList ();
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
