namespace JardinesEf.Entidades.Entidades
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double Cantidad { get; set; }
        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
