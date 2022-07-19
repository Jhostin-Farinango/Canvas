namespace Aplicacion
{
    public interface IFigura
    {
        string Tipo { get; set; }
        string Texto { get; set; }
        string Caracteristicas { get; set; }

        int CalcularArea(string caracteristicas);

        int CalcularEspacioTexto (string caracteristicas);
    }
}
