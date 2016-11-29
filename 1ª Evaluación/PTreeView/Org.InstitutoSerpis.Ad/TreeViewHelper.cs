using Gtk;
using System;

namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		private static void AppendColumns(TreeView treeView, IList list) {
			foreach (string columnName in columnNames) {
				treeView.AppendColumn (columnName, new CellRendererText (),
				                       delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					int column = Array.IndexOf(treeView.Columns, tree_column);
					CellRendererText cellRendererText = (CellRendererText)cell;
					object value = tree_model.GetValue(iter, column);
					cellRendererText.Text = value.ToString();
				}
				);
			}
		}

		public static void AppendColumns(TreeView treeview, Type type){
			PropertyInfo[] propertyInfos = type.GetProperties ();
			List<string> propertyNames = new List<string> ();
			foreach (PropertyInfo propertyInfo in propertyInfos)
				propertyNames.Add (propertyInfo.Name);
			AppendColumns (treeview, propertyNames.toArray ());
		}
		public static void Fill (TreeView, IList list){ 
			Type listType = list.GetType ();
			Type elementType = listType.GetGenericArguments ()[0];
			PropertyInfo[] propertyInfos = elementType.GetProperties();
			int columnIndex = 0;
			foreach (PropertyInfo propertyInfo in propertyInfos){
				string columnName = property.Name;
				TreeView.AppendColumn (columnName, new CellRendererText (), delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					object item = tree_model.GetValue(iter,0);
					object value = propertyInfo.GetValue(item, null);
					CellRendererText cellRendererText = (CellRendererText)cell;
					cellRendererText.Text = value == null ? "" : value.ToString;
					}
				);
			}
			ListStore listStore = new ListStore (typeof(object));
			TreeView.Model = listStore;
			foreach (object item in list)
				listStore.AppendValues(item);
		} 
	}
}