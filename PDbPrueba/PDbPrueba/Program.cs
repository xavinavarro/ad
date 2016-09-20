using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace PDbPrueba {

	class MainClass	{

		public static void Main (string[] args){

		//	Console.WriteLine ("Probando acceso a dbprueba");
			IDbConnection dbConnection = new MySqlConnection (
				"Database=dbprueba;User Id=root;Password=sistemas"
			);

			dbConnection.Open ();

			//Operaciones...
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = "nombre";
			dbDataParameter.Value = "Categoria 4";
			dbCommand.Parameters.Add (dbDataParameter);
			dbCommand.ExecuteNonQuery ();

			

			dbConnection.Close ();

			//readLong ("Introduce el id: ");
		}

		private static long readLong(string label) {
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				try {
					return long.Parse (data);
				} catch {
					Console.WriteLine ("Solo numeros, introduce un numero por favor: ");
				}
			}
		}

	/*	private void close (){

		}

		private void update (){
			
		}

		private void insert (){
			
		}

		private void delete (){
			
		}*/




	}
}