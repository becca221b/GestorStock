namespace WebAPI.Modelo
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha
        { get; set; }
    }
}
