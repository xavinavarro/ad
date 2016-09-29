using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;


namespace PCategoria
{
	class MainClass
	{
		public enum Option {SALIR, NUEVO, EDITAR, BORRAR, LISTAR}

		public static IDbConnection dbConnection;

		public static void Main (string[] args){
			dbConnection = new MySqlConnection (
				"Database=dbprueba;User Id=root;Password=sistemas"
				);

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
			try{
				dbCommand.ExecuteNonQuery ();
			} catch (MySqlException ex) {
				//string userMessage = getUserMessage (ex);
				//if (!userMessage.Equals(""))
				Console.WriteLine (getUserMessage(ex));
			}
		}

		private static int ER_DUP_ENTRY = 1062;
		private static string getUserMessage(MySqlException ex){
			switch (ex.Number){
				case ER_DUP_ENTRY: 
				return "Dato duplicado. Ya existe en la base de datos";
				//default:
				//break;
			}
			return ex.Message;
		}

		private static string UPDATE_SQL = "update categoria set nombre=@nombre where id=@id"; 
		private static void editar() {
			long id = readLong ("Id: "); 
			string nombre = readString("Nombre: "); 
			IDbCommand dbCommand = dbConnection.CreateCommand (); 
			dbCommand.CommandText = UPDATE_SQL;
			addParameter (dbCommand, "id", id);
			addParameter (dbCommand, "nombre", nombre);
			try{
				int filas = dbCommand.ExecuteNonQuery ();
				if (filas==0)
					Console.WriteLine ("No existe ningun registro con ese ID.");
			} catch (MySqlException ex){
				Console.WriteLine (getUserMessage (ex));
			}
		}

		private static string DELETE_SQL = "delete from categoria where id=@id";
		private static void borrar() {
			long id = readLong ("Id: ");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			addParameter (dbCommand, "id", id);
			int filas = dbCommand.ExecuteNonQuery ();
			if (filas == 0)
				Console.WriteLine ("No existe ningun registro con ese ID.");
			//dbCommand.ExecuteNonQuery ();
		}

		private static string SELECT_SQL = "select * from categoria";
		private static void listar() {
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			Console.WriteLine ("{0,5} {1}", "ID", "Nombre");
			while (dataReader.Read()) {
				Console.WriteLine ("{0,5} {1}", dataReader ["id"], dataReader ["Nombre"]);
				dataReader.Close ();
			}
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
				Console.WriteLine ("No puede estar vacío. Vuelve a introducir.");
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
				Console.WriteLine("Opcion invalida. Vuelve a introducir.");
			}
		}
	}
}