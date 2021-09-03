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
    public partial class FrmClientesEdit : Form
    {
        public FrmClientesEdit()
        {
            InitializeComponent();
        }

        private Cliente cliente;
        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
            HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox,0);
            if (cliente != null)
            {
                NombreTextBox.Text = cliente.Nombres;
                ApellidoTextBox.Text = cliente.Apellido;
                CalleTextBox.Text = cliente.Direccion;
                CodPostalTextBox.Text = cliente.CodigoPostal;
                //TelefonoTextBox.Text = cliente.;
                //EmailTextBox.Text=cliente.em;
                PaisesComboBox.SelectedValue = cliente.Pais.PaisId;
                CiudadesComboBox.SelectedValue = cliente.Ciudad.CiudadId;
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
                if (cliente == null)
                {
                    cliente = new Cliente();
                }

                cliente.Nombres = NombreTextBox.Text;
                cliente.Apellido = ApellidoTextBox.Text;
                cliente.Direccion = CalleTextBox.Text;
                cliente.CodigoPostal = CodPostalTextBox.Text;
                cliente.Ciudad = (Ciudad)CiudadesComboBox.SelectedItem;
                cliente.CiudadId = ((Ciudad)CiudadesComboBox.SelectedItem).CiudadId;
                cliente.Pais = (Pais)PaisesComboBox.SelectedItem;
                cliente.PaisId = ((Pais)PaisesComboBox.SelectedItem).PaisId;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(NombreTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox, "Debe ingresar un nombre");
            }
            if (string.IsNullOrEmpty(ApellidoTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(ApellidoTextBox, "Debe ingresar un apellido");
            }
            if (string.IsNullOrEmpty(CalleTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(CalleTextBox, "Debe ingresar una calle");
            }

            if (PaisesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox, "Debe seleccionar una país");
            }
            if (CiudadesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CiudadesComboBox, "Debe seleccionar una ciudad");
            }

            return valido;
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex!=0)
            {
                CiudadesComboBox.Enabled = true;
                var paisId = ((Pais)PaisesComboBox.SelectedItem).PaisId;
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox, paisId);
            }
            else
            {
                CiudadesComboBox.Enabled = false;

            }
        }
    }
}
