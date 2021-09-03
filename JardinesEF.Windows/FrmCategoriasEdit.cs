using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Windows
{
    public partial class FrmCategoriasEdit : Form
    {
        public FrmCategoriasEdit()
        {
            InitializeComponent();
        }
        private Categoria categoria;
        public Categoria GetTipo()
        {
            return categoria;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.NombreCategoria = CategoriaTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(CategoriaTextBox.Text))
            {
                esValido = false;
                errorProvider1.SetError(CategoriaTextBox, "Debe ingresar un país");

            }

            return esValido;
        }

        public void SetTipo(Categoria categoria)
        {
            this.categoria = categoria;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                CategoriaTextBox.Text = categoria.NombreCategoria;
                DescripcionTextBox.Text = categoria.Descripcion;
            }
        }


    }
}
