namespace WebApiREST.Models
{
    public class Pedido
    {
        public int idPedido { get; set; }

        public double LatitudIncial { get; set; }

        public double LongitudInicial { get; set; }

        public double LatitudDestino { get; set; }

        public double LongitudDestino { get; set; }

        public int idUsuario { get; set; }

        public string NombreUsuario { get; set; }
    }
}