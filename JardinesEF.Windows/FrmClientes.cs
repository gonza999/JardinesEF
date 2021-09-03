using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
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
    public partial class FrmClientes : Form
    {
        public FrmClientes(IClientesServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private int cantidadPaginas;
        private int cantidadPorPagina = 20;
        private int paginaActual;

        private readonly IClientesServicios _servicio;
        private List<Cliente> lista;
        private int cantidadRegistros;
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                //lista = _servicio.GetLista();

                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas = CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                CrearBotonesPaginas(cantidadPaginas);
                paginaActual = 1;
                MostrarPaginado(cantidadPorPagina, paginaActual);

                //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                //MostrarDatosEnGrilla();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearBotonesPaginas(int paginas)
        {
            BotonesPanel.Controls.Clear();
            for (int i = 0; i < paginas; i++)
            {
                Button b = new Button()
                {
                    Text = (i + 1).ToString(),
                    Location = new Point(16 + (35 * i), 16),
                    Size = new Size(32, 32)

                };
                b.Click += Miclick;//Le agrego un manejador al evento clic de los botones
                BotonesPanel.Controls.Add(b);//Agregro el botón a la colección de controles del panel
            }
        }
        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            paginaActual = int.Parse(b.Text);
            MostrarPaginado(cantidadPorPagina, paginaActual);
        }

        private void MostrarPaginado(int cantidadPorPagina, int paginaActual)
        {
            lista = _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }

        private int CalcularCantidadDePaginas(int totalRegistros, int porPagina)
        {
            if (totalRegistros < porPagina)
            {
                return 1;
            }

            if (totalRegistros % porPagina > 0)
            {
                return totalRegistros / porPagina + 1;
            }
            else
            {
                return totalRegistros / porPagina;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var cliente in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, cliente);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            PaginaActualLabel.Text = paginaActual.ToString();

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmClientesEdit frm = new FrmClientesEdit() { Text = "Nueva Cliente" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Cliente cliente = frm.GetCliente();
                    if (_servicio.Existe(cliente))
                    {
                        MessageBox.Show("Categoría existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(cliente);
                    DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);
                    HelperGrid.SetearFila(r, cliente);
                    HelperGrid.AgregarFila(DatosDataGridView, r);

                    cantidadRegistros = _servicio.GetCantidad();
                    CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                    MessageBox.Show("Registro guardado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Cliente cliente = (Cliente)r.Tag;
            Cliente categoriaCopia = (Cliente)cliente.Clone();
            FrmClientesEdit frm = new FrmClientesEdit() { Text = "Editar Cliente" };
            frm.SetCliente(cliente);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                cliente = frm.GetCliente();
                if (_servicio.Existe(cliente))
                {
                    HelperGrid.SetearFila(r, categoriaCopia);
                    MessageBox.Show("Cliente existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _servicio.Guardar(cliente);
                HelperGrid.SetearFila(r, cliente);
                MessageBox.Show("Registro Editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                HelperGrid.SetearFila(r, categoriaCopia);
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Cliente cliente = (Cliente)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {cliente.Nombres}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(cliente.ClienteId);
                HelperGrid.BorrarFila(DatosDataGridView, r);

                cantidadRegistros = _servicio.GetCantidad();
                CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
