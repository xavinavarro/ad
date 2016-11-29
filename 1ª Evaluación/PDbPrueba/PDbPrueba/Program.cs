using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace PDbPrueba {

	class MainClass	{

		public enum Option {SALIR, NUEVO, EDITAR, BORRAR, LISTAR}

		public static void Main (string[] args){

			//	Console.WriteLine ("Probando acceso a dbprueba");
			IDbConnection dbConnection = new MySqlConnection (
				"Database=dbprueba;User Id=root;Password=sistemas"
			);
			
			dbConnection.Open ();

			while (true){
				Option option = getOption ();
				switch (option) {
				case Option.SALIR:
					return;
				case Option.NUEVO:
					nuevo ();
					break;
				case Option.EDITAR:
					editar ();
					break;
				case Option.LISTAR:

					break;
				}
			}


		}
			private static int getOpcion (){
				while (true){
					Console.WriteLine ("*--MENU--*");
					Console.WriteLine ("1.- Nuevo");
					Console.WriteLine ("2.- Editar");
					Console.WriteLine ("3.- Borrar");
					Console.WriteLine ("4.- Listar");
					Console.WriteLine ("5.- Salir");
					Console.WriteLine ("Elige una opcion: ");

					string opcion = Console.ReadLine ();
					if (Regex.IsMatch (opcion, "^[12345]$"))
						return int.Parse (opcion);

					Console.WriteLine("Opcion no valida, introduce un numero valido.");
				 	 
					
				switch(opcion){


					case "1":
						Console.Clear();
						
						return 1;

					case "2":
						Console.Clear();
						return 2;

					case "3":
						Console.Clear();

						return 3;

					case "4":
						Console.Clear();

						return 4;

					case "5":
						Console.Clear();

						return 5;

				}

			}
			dbConnection.Close ();

		}
	}
}