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
    public partial class FrmProductos : Form
    {
        public FrmProductos(IProductosServicios servicio)
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

        private readonly IProductosServicios _servicio;
        private List<Producto> lista;
        private int cantidadRegistros;
        private void FrmProductos_Load(object sender, EventArgs e)
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
            foreach (var producto in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, producto);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            PaginaActualLabel.Text = paginaActual.ToString();

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosEdit frm = new FrmProductosEdit() { Text = "Nueva Producto" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Producto producto = frm.GetProducto();
                    if (_servicio.Existe(producto))
                    {
                        MessageBox.Show("Producto existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(producto);
                    DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);
                    HelperGrid.SetearFila(r, producto);
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
            Producto producto = (Producto)r.Tag;
            Producto productoCopia = (Producto)producto.Clone();
            FrmProductosEdit frm = new FrmProductosEdit() { Text = "Editar Producto" };
            frm.SetProducto(producto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                producto = frm.GetProducto();
                if (_servicio.Existe(producto))
                {
                    HelperGrid.SetearFila(r, productoCopia);
                    MessageBox.Show("Producto existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _servicio.Guardar(producto);
                HelperGrid.SetearFila(r, producto);
                MessageBox.Show("Registro Editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                HelperGrid.SetearFila(r, productoCopia);
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
            Producto producto = (Producto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {producto.NombreProducto}?",
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
                _servicio.Borrar(producto.ProductoId);
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
