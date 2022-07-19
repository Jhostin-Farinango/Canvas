using Newtonsoft.Json;

namespace Aplicacion
{
    public class JsonProceso
    {
        public bool ValidarJson()
        {

            try 
            {
                
                StreamReader r = new StreamReader("Figura.json");
                string jsonString = r.ReadToEnd();

                ModeloLista jsonObjecto = JsonConvert.DeserializeObject<ModeloLista>(jsonString);
                bool error = false;

                foreach (ModeloFigura fig in jsonObjecto.Lista)
                {
                    if (fig.Tipo != "circulo" && fig.Tipo != "rectangulo" ) 
                    {
                        error = true;
                    }
                }

                return !error;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<IFigura> ProcesarJson()
        {

            Figura figura = new Figura();
            List<IFigura> figuras = new List<IFigura>();

            StreamReader r = new StreamReader("Figura.json");
            string jsonString = r.ReadToEnd();

            ModeloLista jsonObjecto = JsonConvert.DeserializeObject<ModeloLista>(jsonString);

            foreach (ModeloFigura fig in jsonObjecto.Lista)
            {

                IFigura instanciaFigura = figura.GenerarFigura(fig.Tipo);
                instanciaFigura.Tipo = fig.Tipo;
                instanciaFigura.Texto = fig.Texto;
                instanciaFigura.Caracteristicas = fig.Caracteristicas;
                figuras.Add(instanciaFigura);

            }

            return figuras;

        }
    }
}
