using System.Collections.Generic;
using JardinesEF.Datos.Comun.Facades;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface ICiudadesServicios
    {
        List<Ciudad> GetLista(int registros, int pagina);
        Ciudad GetEntityPorId(int id);
        void Guardar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionado(Ciudad ciudad);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);

        List<Ciudad> GetLista();
        List<Ciudad> GetLista(int paisId);
    }
}
