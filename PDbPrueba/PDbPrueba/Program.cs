using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Probando acceso a dbprueba");
			MySqlConnection mySqlConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");

			mySqlConnection.Open ();

			//Operaciones...
			//mySqlConnection.CreateCommand ().ExecuteScalar ();


			mySqlConnection.Close ();
		}

		private void close (){

		}

		private void update (){
		
		}

		private void insert (){
		
		}

		private void delete (){
		
		}




	}
}