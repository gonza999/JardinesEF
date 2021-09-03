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
using JardinesEF.Windows.Helpers;

namespace JardinesEF.Windows
{
    public partial class FrmCiudadesEdit : Form
    {
        public FrmCiudadesEdit()
        {
            InitializeComponent();
        }

        private Ciudad ciudad;
        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
            if (ciudad!=null)
            {
                CiudadTextBox.Text = ciudad.NombreCiudad;
                PaisesComboBox.SelectedValue = ciudad.Pais.PaisId;
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
                if (ciudad==null)
                {
                    ciudad = new Ciudad();
                }

                ciudad.NombreCiudad = CiudadTextBox.Text;
                ciudad.Pais = (Pais)PaisesComboBox.SelectedItem;
                ciudad.PaisId = ((Pais)PaisesComboBox.SelectedItem).PaisId;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(CiudadTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(CiudadTextBox,"Debe ingresar una ciudad");
            }

            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar una país");
            }

            return valido;
        }
    }
}
