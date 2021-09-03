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
    public partial class FrmPaisesEdit : Form
    {
        public FrmPaisesEdit()
        {
            InitializeComponent();
        }
        private Pais pais;
        public Pais GetTipo()
        {
            return pais;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }

                pais.NombrePais = PaisTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(PaisTextBox.Text))
            {
                esValido = false;
                errorProvider1.SetError(PaisTextBox, "Debe ingresar un país");

            }

            return esValido;
        }

        public void SetTipo(Pais pais)
        {
            this.pais = pais;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                PaisTextBox.Text = pais.NombrePais;
            }
        }

    }
}
