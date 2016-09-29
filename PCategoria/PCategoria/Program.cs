using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Data;


namespace PCategoria
{
	class MainClass
	{
		public enum Option {SALIR, NUEVO, EDITAR, BORRAR, LISTAR}

		public static IDbConnection dbConnection;

		public static void Main (string[] args)
		{
			dbConnection = new MySqlConnection (
				"Database=dbprueba;User Id=root;Password=sistemas"
				);
			//TODO valorar si merece la pena una inicialización perezosa
			dbConnection.Open ();
			while (true) {
				Option option = getOption ();
				switch (option) {
					case Option.SALIR:
					dbConnection.Close ();
					return;
					case Option.NUEVO:
					nuevo ();
					break;
					case Option.EDITAR:
					editar ();
					break;
					case Option.BORRAR:
					borrar ();
					break;
					case Option.LISTAR:
					listar ();
					break;
				}

			}
		}

		private static string INSERT_SQL = "insert into categoria (nombre) values (@nombre)";
		private static void nuevo() {
			string nombre = readString("Nombre: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			addParameter (dbCommand, "nombre", nombre);
			dbCommand.ExecuteNonQuery ();
		}

		private static string UPDATE_SQL = "update categoria set nombre=@nombre where id=@id";
		private static void editar() {
			long id = readLong ("Id: ");
			string nombre = readString("Nombre: ");

		}

		private static string DELETE_SQL = "delete from categoria where id=@id";
		private static void borrar() {
			long id = readLong ("Id: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			addParameter (dbCommand, "id", id);
			//TODO comprobar si devuelve 0 (ningún registro afectado)...
			dbCommand.ExecuteNonQuery ();
		}

		private static void listar() {
		}

		private static void addParameter(IDbCommand dbCommand, string name, object value) {
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}

		private static long readLong(string label) {
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				try {
					return long.Parse (data);
				} catch {
					Console.WriteLine ("Sólo números, por favor. Vuelve a introducir");
				}
			}
		}

		private static string readString (string label) {
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				data = data.Trim ();
				if (!data.Equals (""))
					return data;
				Console.WriteLine ("No puede quedar vacío. Vuelve a introducir.");
			}
		}

		private static Option getOption() {
			string pattern = "^[01234]$";
			while (true) {
				Console.WriteLine ("0- Salir");
				Console.WriteLine ("1- Nuevo");
				Console.WriteLine ("2- Editar");
				Console.WriteLine ("3- Borrar");
				Console.WriteLine ("4- Listar");
				string option = Console.ReadLine ();
				if (Regex.IsMatch (option, pattern))
					return (Option)int.Parse (option);
				Console.WriteLine("Opción inválida. Vuelve a introducir.");
			}
		}
	}
}