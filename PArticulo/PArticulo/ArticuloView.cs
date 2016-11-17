using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView (Articulo articulo) : base(Gtk.WindowType.Toplevel) {
			this.Build ();

			entryNombre.Text = articulo.Nombre;
			//spinButtonPrecio.Value = articulo.Precio;

			spinButtonPrecio.Value = 0; //stetic bug
			saveAction.Sensitive = false;
			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");
				articulo.Nombre = entryNombre.Text;
				articulo.Precio = (decimal)spinButtonPrecio.Value;
				articulo.Categoria = (long?)ComboBoxHelper.GetId(comboBoxCategoria);
				ArticuloDao.Save(articulo);
			};

			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};

			fill();
		}

		private void fill() {
			IList list = CategoriaDao.GetList ();
			ComboBoxHelper.Fill(comboBoxCategoria, list, "Nombre");
		}

	}
}