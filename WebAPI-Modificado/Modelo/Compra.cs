namespace WebAPI.Modelo
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

    }
}
