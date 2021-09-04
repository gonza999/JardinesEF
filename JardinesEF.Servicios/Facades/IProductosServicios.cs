using JardinesEf.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinesEF.Servicios.Facades
{
    public interface IProductosServicios
    {
        List<Producto> GetLista(int registros, int pagina);
        Producto GetEntityPorId(int id);
        void Guardar(Producto producto);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
        List<Producto> GetLista();
    }
}
