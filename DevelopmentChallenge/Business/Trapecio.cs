using System;

namespace DevelopmentChallenge.Business
{
    public class Trapecio : IFormaGeometrica
    {
        public Entities.FormaGeometrica Forma { get; set; }

        public decimal CalcularArea()
        {
            decimal area = ((this.Forma.Lado + this.Forma.LadoSuperior) * this.Forma.Altura) / 2;

            return area;
        }

        public decimal CalcularPerimetro()
        {
            decimal diff = (this.Forma.LadoSuperior - this.Forma.Lado) / 2;
            decimal lateralCuadrado = (diff * diff) + (this.Forma.Altura * this.Forma.Altura);
            decimal lateral = (decimal)Math.Sqrt((double)lateralCuadrado);

            decimal perimetro = this.Forma.Lado + this.Forma.LadoSuperior + (lateral * 2);

            return perimetro;
        }
    }
}
