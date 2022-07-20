using Libreria;

namespace Aplicacion
{
    class Program
    {
        static void Main(string[] args)
        {

            JsonProceso jsonProceso = new JsonProceso();
            bool jsonValido = jsonProceso.ValidarJson();

            if (jsonValido)
            {

                CalCanvas calCanvas = new CalCanvas();

                calCanvas.ancho = 55;
                calCanvas.alto = 55;
                calCanvas.fuente = 12;

                List<IFigura> figuras = jsonProceso.ProcesarJson();

                List<int> listaAreas = new List<int>();
                List<string> listaTipos = new List<string>();
                List<string> listaTextos = new List<string>();
                List<int> listaEspaciosTextos = new List<int>();

                foreach (IFigura fig in figuras)
                {
                    listaAreas.Add(fig.CalcularArea(fig.Caracteristicas));
                    listaTipos.Add(fig.Tipo);
                    listaTextos.Add(fig.Texto);
                    listaEspaciosTextos.Add(fig.CalcularEspacioTexto(fig.Caracteristicas));
                }

                int[] areas = listaAreas.ToArray();
                string[] tipos = listaTipos.ToArray();
                string[] textos = listaTextos.ToArray();
                int[] espaciosTextos = listaEspaciosTextos.ToArray();

                Console.WriteLine(calCanvas.procesar(areas, tipos, textos, espaciosTextos));
            
            }
            else
            {
                Console.WriteLine("La sintaxis de su JSON no es la correcta, revisela.");
            }

        }
    }

}