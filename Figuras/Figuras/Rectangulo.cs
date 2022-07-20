namespace Aplicacion
{
    public class Rectangulo : IFigura
    {
        public string Tipo { get; set; }
        public string Texto { get; set; }
        public string Caracteristicas { get; set; }

        public int CalcularArea(string caracteristicas)
        {
            string preAncho = caracteristicas.Split(';')[0];
            string preAlto = caracteristicas.Split(';')[1];
            int ancho = Int32.Parse(preAncho.Split('=')[1]);
            int alto = Int32.Parse(preAlto.Split('=')[1]);
            int area = ancho * alto;
            return area;
        }

        public int CalcularEspacioTexto(string caracteristicas)
        {
            string preAncho = caracteristicas.Split(';')[0];
            int ancho = Int32.Parse(preAncho.Split('=')[1]);
            return ancho;
        }
    }
}
