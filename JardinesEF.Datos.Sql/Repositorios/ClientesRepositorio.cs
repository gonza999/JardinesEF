using JardinesEf.Entidades.Entidades;
using JardinesEF.Datos.Comun.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinesEF.Datos.Sql.Repositorios
{
    public class ClientesRepositorio:IClientesRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public ClientesRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Cliente> GetLista(int cantidad, int pagina)
        {
            try
            {
                return _context.Clientes
                    .OrderBy(p => p.Apellido)
                    .Skip(cantidad * (pagina - 1))
                    .Take(cantidad)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }

        }

        public Cliente GetTEntityPorId(int id)
        {
            try
            {
                return _context.Clientes.SingleOrDefault(p => p.ClienteId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Cliente clientes)
        {
            try
            {
                if (clientes.ClienteId == 0)
                {
                    //Cuando el id=0 entonces la entidad es nueva ==>alta
                    _context.Clientes.Add(clientes);

                }
                else
                {
                    var clienteInDb =
                        _context.Clientes.SingleOrDefault(p => p.ClienteId == clientes.ClienteId);
                    if (clienteInDb == null)
                    {
                        throw new Exception("Cliente inexistente");
                    }

                    clienteInDb.Apellido = clientes.Apellido;
                    clienteInDb.CiudadId = clientes.CiudadId;
                    //clienteInDb.Codigo = clientes.Codigo;
                    clienteInDb.CodigoPostal = clientes.CodigoPostal;
                    clienteInDb.Direccion = clientes.Direccion;
                    clienteInDb.Nombres = clientes.Nombres;
                    clienteInDb.Ordenes = clientes.Ordenes;
                    clienteInDb.PaisId = clientes.PaisId;
                    _context.Entry(clienteInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    return _context.Clientes.Any(p => p.Nombres == cliente.Nombres);
                }

                return _context.Clientes.Any(p => p.Nombres == cliente.Nombres
                                                         && p.ClienteId != cliente.ClienteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            throw new NotImplementedException();
        }


        public int GetCantidad()
        {
            try
            {
                return _context.Clientes.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            Cliente clienteInDb = null;
            try
            {
                clienteInDb = _context.Clientes
                    .SingleOrDefault(p => p.ClienteId == id);
                if (clienteInDb == null) return;
                _context.Entry(clienteInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(clienteInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

    }
}
