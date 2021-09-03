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
    }
}
