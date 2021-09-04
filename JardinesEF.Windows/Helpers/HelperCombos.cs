using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Ninject;

namespace JardinesEF.Windows.Helpers
{
    public class HelperCombos
    {
        public static void CargarDatosComboPaises(ref ComboBox combo)
        {
            IPaisesServicios servicio = DI.Create<IPaisesServicios>();
            List<Pais> lista = servicio.GetLista();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "<Seleccione País>"
            };
            lista.Insert(0,defaultPais);
            combo.DataSource = lista;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex = 0;

        }

        internal static void CargarDatosComboCiudades(ref ComboBox ciudadesComboBox, int paisId)
        {
            ICiudadesServicios servicio = DI.Create<ICiudadesServicios>();
            List<Ciudad> lista = servicio.GetLista(paisId);
            var defaultCiudad = new Ciudad()
            {
                CiudadId = 0,
                NombreCiudad = "<Seleccione Ciudad>"
            };
            lista.Insert(0, defaultCiudad);
            ciudadesComboBox.DataSource = lista;
            ciudadesComboBox.DisplayMember = "NombreCiudad";
            ciudadesComboBox.ValueMember = "CiudadId";
            ciudadesComboBox.SelectedIndex = 0;
        }

        internal static void CargarDatosComboCategorias(ref ComboBox categoriaComboBox)
        {
            ICategoriasServicios servicio = DI.Create<ICategoriasServicios>();
            List<Categoria> lista = servicio.GetLista();
            var defaultCategoria = new Categoria()
            {
                CategoriaId = 0,
                NombreCategoria = "<Seleccione Categoria>"
            };
            lista.Insert(0, defaultCategoria);
            categoriaComboBox.DataSource = lista;
            categoriaComboBox.DisplayMember = "NombreCategoria";
            categoriaComboBox.ValueMember = "CategoriaId";
            categoriaComboBox.SelectedIndex = 0;
        }

        internal static void CargarDatosComboProveedores(ref ComboBox proveedoresComboBox)
        {
            //IProveedoresServicios servicio = DI.Create<IProveedoresServicios>();
            //List<Proveedor> lista = servicio.GetLista();
            List<Proveedor> lista = new List<Proveedor>();
            var defaultProveedor = new Proveedor()
            {
                ProveedorId = 0,
                NombreProveedor = "<Seleccione Proveedor>"
            };
            lista.Insert(0, defaultProveedor);
            proveedoresComboBox.DataSource = lista;
            proveedoresComboBox.DisplayMember = "NombreProveedor";
            proveedoresComboBox.ValueMember = "ProveedorId";
            proveedoresComboBox.SelectedIndex = 0;
        }
    }
}
