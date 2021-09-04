using JardinesEf.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JardinesEF.Windows.Helpers
{
    public class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static DataGridViewRow CrearFila(DataGridView dataGridView)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView);
            return r;
        }

        public static void AgregarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Add(r);
        }

        public static void BorrarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Remove(r);
        }

        public static void SetearFila(DataGridViewRow r, Object obj)
        {
            if (obj is Pais)
            {
                r.Cells[0].Value = ((Pais)obj).NombrePais;
            }
            if (obj is Categoria)
            {
                r.Cells[0].Value = ((Categoria)obj).NombreCategoria;
            }

            if (obj is Ciudad)
            {
                r.Cells[0].Value = ((Ciudad) obj).NombreCiudad;
                r.Cells[1].Value = ((Ciudad) obj).Pais.NombrePais;
            }
            if (obj is Cliente)
            {
                r.Cells[0].Value = ((Cliente)obj).Apellido + " " + ((Cliente)obj).Nombres;
                r.Cells[1].Value = ((Cliente)obj).Ciudad.NombreCiudad;
                r.Cells[2].Value = ((Cliente)obj).Pais.NombrePais;
            }
            if (obj is Producto)
            {
                r.Cells[0].Value = ((Producto)obj).NombreProducto;
                r.Cells[1].Value = ((Producto)obj).Categoria.NombreCategoria;
                r.Cells[2].Value = ((Producto)obj).PrecioUnitario;
                r.Cells[3].Value = ((Producto)obj).UnidadesEnStock;
                r.Cells[4].Value = ((Producto)obj).Suspendido;

            }

            r.Tag = obj;
        }

    }
}
