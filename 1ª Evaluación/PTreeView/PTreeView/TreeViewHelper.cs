using System;
using Gtk;


namespace Org.InstitutoSerpis.Ad
{
	public  class TreeViewHelper {
		public static void AppendColumns (TreeView treeview, string[]  columnNames) {
			int index = 0;
			foreach (string columnName in columnNames) {
				int column = index++;
				treeview.AppendColumn (columnName, new CellRendererText (),
					delegate (TreeViewColumn tree_column, CellRenderer CellView, TreeModel tree_model){
				 		int column = Array.IndexOf(treeview.Columns, tree_column);
						CellRendererText cellRendererText = (CellRendererText)cell;
						object value = tree_model.GetValue(iter, column);
						cellRendererText.Text = value.ToString();
				}
			);
			}
		}
	}
}