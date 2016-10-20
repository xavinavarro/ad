using System;
using System.Collections.Generic;
using System.Data;
using GLib;
using Gtk;
using MySql.Data.MySqlClient;
using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection; 
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		mySqlConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
			);
		mySqlConnection.Open ();


		string selectSql = "select * from articulo";
		IDbCommand dbCommand = mySqlConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			long id = dataReader ["id"];
			string nombre = dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
			long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];
			Articulo articulo = new Articulo (id, nombre, precio, null);
			List.Add (articulo);

		}
		dataReader.Close ();

		TreeViewHelper.Fill (TreeView, list);


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
