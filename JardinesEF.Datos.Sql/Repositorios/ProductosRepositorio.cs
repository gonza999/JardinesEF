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
    public class ProductosRepositorio:IProductosRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public ProductosRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Producto> GetLista(int cantidad, int pagina)
        {
            try
            {
                return _context.Productos
                    .Include(p=>p.Categoria)
                    .Include(p=>p.Proveedor)
                    .OrderBy(p => p.NombreProducto)
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

        public Producto GetTEntityPorId(int id)
        {
            try
            {
                return _context.Productos.SingleOrDefault(p => p.ProductoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                _context.Categorias.Attach(producto.Categoria);
                _context.Proveedores.Attach(producto.Proveedor);

                if (producto.ProductoId == 0)
                {
                    //Cuando el id=0 entonces la entidad es nueva ==>alta
                    _context.Productos.Add(producto);

                }
                else
                {
                    var productoInDb =
                        _context.Productos.SingleOrDefault(p => p.ProductoId == producto.ProductoId);
                    if (productoInDb == null)
                    {
                        throw new Exception("Ciudad inexistente");
                    }

                    productoInDb.CategoriaId = producto.CategoriaId;
                    productoInDb.DetalleOrdenes = producto.DetalleOrdenes;
                    productoInDb.NivelDeReposicion = producto.NivelDeReposicion;
                    productoInDb.NombreLatin = producto.NombreLatin;
                    productoInDb.NombreProducto = producto.NombreProducto;
                    productoInDb.PrecioUnitario = producto.PrecioUnitario;
                    productoInDb.ProveedorId = producto.ProveedorId;
                    productoInDb.Suspendido = producto.Suspendido;
                    productoInDb.UnidadesEnStock = producto.UnidadesEnStock;

                    _context.Entry(productoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                {
                    return _context.Productos.Any(c => c.NombreProducto == producto.NombreProducto &&
                                                      c.NombreLatin == producto.NombreLatin);
                }

                return _context.Productos.Any(c => c.NombreProducto == producto.NombreProducto
                                                  && c.NombreLatin == producto.NombreLatin
                                                         && c.ProductoId != producto.ProductoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Producto TEntity)
        {
            throw new NotImplementedException();
        }


        public int GetCantidad()
        {
            try
            {
                return _context.Productos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            Producto productoInDb = null;
            try
            {
                productoInDb = _context.Productos
                    .SingleOrDefault(p => p.ProductoId == id);
                if (productoInDb == null) return;
                _context.Entry(productoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(productoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Producto> GetLista()
        {
            try
            {
                return _context.Productos.OrderBy(p => p.NombreProducto).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
