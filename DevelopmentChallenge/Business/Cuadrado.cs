namespace DevelopmentChallenge.Business
{
    public class Cuadrado : IFormaGeometrica
    {
        public Entities.FormaGeometrica Forma { get; set; }

        public decimal CalcularArea()
        {
            decimal area = this.Forma.Lado * this.Forma.Lado;

            return area;
        }

        public decimal CalcularPerimetro()
        {
            decimal perimetro = this.Forma.Lado * 4;

            return perimetro;
        }
    }
}
