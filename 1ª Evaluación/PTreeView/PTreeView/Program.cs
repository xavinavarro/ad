using MySql.Data.MySqlClient;
using System;
using System.Data;
using Gtk;


namespace PDbPrueba {

	class MainClass	{

		public static void Main (string[] args)
		{
			Application.Init ();
			Window win = new Window ();
			win.Show ();
			Application.Run ();
		}
	}
}