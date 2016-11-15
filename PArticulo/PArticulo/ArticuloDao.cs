using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public class EntityDao{
		private const string SELECT_SQL = "select * from {0}";
		public static List<TEntity> GetList<TEntity>(){
		
			Type typeEntity = typeof(TEntity);
			List<TEntity> list = new List<TEntity> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = string.Format (SELECT_SQL, typeEntity.Name.ToLower ());
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				TEntity item = Activator.CreateInstance<TEntity> ();
				foreach (PropertyInfo propertyInfo in typeEntity.GetProperties()) {
					object value = dataReader [propertyInfo.Name.ToLower ()];
					if (value is DBNull)
						value = null;
					propertyInfo.SetValue (item, value, null);
				}
				list.Add (item);
			}
			dataReader.Close ();
			return list;
		}
	}

	public class ArticuloDao
	{

		private const string SELECT_ID_SQL = "select * from articulo";
		public static Articulo Load(long id){
			List<Articulo> list = new List<Articulo>();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_ID_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
				long? categoria = dataReader["categoria"] is DBNull ? null : (long?)dataReader["categoria"];
				Articulo articulo = new Articulo(id, nombre, precio, categoria);
				list.Add (articulo);
			}
			dataReader.Close ();
			return list;
		}

		private const string INSERT_SQL = "insert into articulo (nombre, precio, categoria) " +
			"values (@nombre, @precio, @categoria)";
		public static void Save(Articulo articulo) {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = INSERT_SQL;
			DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter(dbCommand, "categoria", articulo.Categoria);
			dbCommand.ExecuteNonQuery();
		}

		private const string DELETE_SQL = "delete from articulo where id = @id";
		public static void Delete(object id) {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
		}
	}
}

