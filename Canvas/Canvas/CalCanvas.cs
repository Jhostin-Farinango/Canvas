namespace Libreria
{
    public class CalCanvas
    {
        public int ancho;
        public int alto;
        public int fuente;
        public double tamPuntoPixel = 0.5;

        public string procesar(int[] areas, string[] tipos, string[] textos, int[] espaciosTextos)
        {
            int areaTotal = CalcularArea(areas);
            bool canvasValido = ValidarAreaCanvas(areaTotal);

            string respuesta = "";

            if (canvasValido)
            {
                string[] figurasIncorrectas = ListarFigurasIncorrectas(areas, tipos, textos, espaciosTextos);

                if(figurasIncorrectas.Length > 0) 
                {
                    respuesta = "El texto de una o más figuras no entran en su espacio, en " + figurasIncorrectas[0];
                    for (int i = 1; i < figurasIncorrectas.Length; i++)
                    {
                        if(i == (figurasIncorrectas.Length - 1))
                        {
                            respuesta = respuesta + " y " + figurasIncorrectas[i];
                        }
                        else
                        {
                            respuesta = respuesta + ", " + figurasIncorrectas[i];
                        }
                    }
                }
                else
                {
                    respuesta = "Los elementos se pueden dibujar correctamente y sus textos dentro del canvas";

                }
            }
            else
            {
                respuesta = "La suma del área de las figuras(" + areaTotal + ") es mayor que el área del canvas(" + (ancho * alto) + ")";
            }

            return respuesta;
        }

        public int CalcularArea(int[] areas)
        {
            int areaTotal = 0;

            for(int i = 0; i< areas.Length; i++)
            {
                areaTotal = areaTotal + areas[i];
            }

            return areaTotal;
        }

        public bool ValidarAreaCanvas(int areaTotal)
        {
            int areaCanvas = ancho * alto;
            if(areaCanvas >= areaTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] ListarFigurasIncorrectas(int[] areas, string[] tipos, string[] textos, int[] espaciosTextos) 
        {
            List<string> listaFigurasIncorrectas = new List<string>();

            for (int i = 0; i < espaciosTextos.Length; i++) 
            {
                int longitudTexto = CalcularLongitudTexto(textos[i]);
                bool validado = ValidarTexto(espaciosTextos[i], longitudTexto);

                if (!validado)
                {
                    string errorTextoFigura = "la figura " + tipos[i] + " solo dispone de un espacio de " + ((espaciosTextos[i] / 3) * 2) + " pero el texto '" + textos[i] + "' consume un espacio de " + longitudTexto;
                    listaFigurasIncorrectas.Add(errorTextoFigura);
                }
            }

            string[] figurasIncorrectas = listaFigurasIncorrectas.ToArray();

            return figurasIncorrectas;
        }

        public bool ValidarTexto(int espacio, int longitudTexto)
        {
            double espacioFigura = (espacio / 3) * 2;
            if(espacioFigura >= longitudTexto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CalcularLongitudTexto(string texto)
        {
            double longitudTexto = fuente * tamPuntoPixel * texto.Length;
            return (int)longitudTexto;
        }

    }
}