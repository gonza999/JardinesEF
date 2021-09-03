using JardinesEf.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinesEF.Servicios.Facades
{
    public interface IClientesServicios
    {
        List<Cliente> GetLista(int registros, int pagina);
        Cliente GetEntityPorId(int id);
        void Guardar(Cliente cliente);
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
    }
}
