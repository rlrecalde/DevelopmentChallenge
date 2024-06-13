namespace DevelopmentChallenge.Business
{
    public interface IFormaGeometrica
    {
        Entities.FormaGeometrica Forma { get; set; }

        decimal CalcularArea();

        decimal CalcularPerimetro();
    }
}
