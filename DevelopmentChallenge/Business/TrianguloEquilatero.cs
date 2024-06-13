using System;

namespace DevelopmentChallenge.Business
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        public Entities.FormaGeometrica Forma { get; set; }

        public decimal CalcularArea()
        {
            decimal area = ((decimal)Math.Sqrt(3) / 4) * this.Forma.Lado * this.Forma.Lado;

            return area;
        }

        public decimal CalcularPerimetro()
        {
            decimal perimetro = this.Forma.Lado * 3;

            return perimetro;
        }
    }
}
