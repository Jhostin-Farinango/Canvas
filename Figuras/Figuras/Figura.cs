namespace Aplicacion
{
    public class Figura
    {
        
        public IFigura GenerarFigura(string figura)
        {
            if(figura == "circulo")
            {
                return new Circulo();
            }

            else if(figura == "rectangulo")
            {
                return new Rectangulo();
            }

            else
            {
                return new FiguraInexistente();
            }
        }

    }
}
