using JardinesEf.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinesEF.Servicios.Facades
{
    public interface IPaisesServicios
    {
        List<Pais> GetLista(int registros, int pagina);
        Pais GetEntityPorId(int id);
        void Guardar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
        List<Pais> GetLista();
    }
}
