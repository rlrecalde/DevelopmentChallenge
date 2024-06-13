namespace DevelopmentChallenge.Business
{
    public class Rectangulo : IFormaGeometrica
    {
        public Entities.FormaGeometrica Forma { get; set; }

        public decimal CalcularArea()
        {
            decimal area = this.Forma.Lado * this.Forma.Altura;

            return area;
        }

        public decimal CalcularPerimetro()
        {
            decimal perimetro = (this.Forma.Lado * 2) + (this.Forma.Altura * 2);

            return perimetro;
        }
    }
}
