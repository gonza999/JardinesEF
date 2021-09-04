using JardinesEf.Entidades.Entidades;
using JardinesEF.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JardinesEF.Windows
{
    public partial class FrmProductosEdit : Form
    {
        public FrmProductosEdit()
        {
            InitializeComponent();
        }

        private Producto producto;
        public void SetProducto(Producto producto)
        {
            this.producto = producto;
        }

        public Producto GetProducto()
        {
            return producto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboCategorias(ref CategoriasComboBox);
            HelperCombos.CargarDatosComboProveedores(ref ProveedoresComboBox);
            if (producto != null)
            {
                ProductoTextBox.Text = producto.NombreProducto;
                LatinTextBox.Text = producto.NombreLatin;
                PrecioUnitarioTextBox.Text = producto.PrecioUnitario.ToString();
                StockTextBox.Text = producto.UnidadesEnStock.ToString();
                NivelDeReposicionTextBox.Text = producto.NivelDeReposicion.ToString();
                SuspendidoCheckBox.Checked = producto.Suspendido;
                CategoriasComboBox.SelectedValue = producto.Categoria.CategoriaId;
                ProveedoresComboBox.SelectedValue = producto.Proveedor.ProveedorId;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.NombreProducto = ProductoTextBox.Text;
                producto.NombreLatin = LatinTextBox.Text;
                producto.PrecioUnitario =decimal.Parse (PrecioUnitarioTextBox.Text);
                producto.UnidadesEnStock = int.Parse(NivelDeReposicionTextBox.Text);
                producto.Categoria = (Categoria)CategoriasComboBox.SelectedItem;
                producto.Proveedor = (Proveedor)ProveedoresComboBox.SelectedItem;
                producto.ProveedorId = ((Proveedor)ProveedoresComboBox.SelectedItem).ProveedorId;
                producto.CategoriaId = ((Categoria)CategoriasComboBox.SelectedItem).CategoriaId;
                producto.NivelDeReposicion = int.Parse(NivelDeReposicionTextBox.Text);
                producto.Suspendido = SuspendidoCheckBox.Checked;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ProductoTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(ProductoTextBox, "Debe ingresar un producto");
            }
            if (string.IsNullOrEmpty(LatinTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(LatinTextBox, "Debe ingresar un nombre en latin");
            }
            if (string.IsNullOrEmpty(PrecioUnitarioTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(PrecioUnitarioTextBox, "Debe ingresar un precio");
            }
            if (string.IsNullOrEmpty(StockTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(StockTextBox, "Debe ingresar un stock");
            }
            if (string.IsNullOrEmpty(NivelDeReposicionTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(NivelDeReposicionTextBox, "Debe ingresar un nivel de reposicion");
            }

            if (CategoriasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CategoriasComboBox, "Debe seleccionar una categoria");
            }
            if (ProveedoresComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProveedoresComboBox, "Debe seleccionar un proveedor");
            }

            return valido;
        }

      
    }
}
