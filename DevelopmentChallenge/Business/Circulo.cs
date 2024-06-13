using System;

namespace DevelopmentChallenge.Business
{
    public class Circulo : IFormaGeometrica
    {
        public Entities.FormaGeometrica Forma { get; set; }

        public decimal CalcularArea()
        {
            decimal area = (decimal)Math.PI * (this.Forma.Lado / 2) * (this.Forma.Lado / 2);

            return area;
        }

        public decimal CalcularPerimetro()
        {
            decimal perimetro = (decimal)Math.PI * this.Forma.Lado;

            return perimetro;
        }
    }
}
