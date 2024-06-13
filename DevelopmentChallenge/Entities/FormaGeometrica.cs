namespace DevelopmentChallenge.Entities
{
    public class FormaGeometrica
    {
        public ShapeType ShapeType { get; set; }

        public decimal Lado { get; set; }

        public decimal Altura { get; set; }

        public decimal LadoSuperior { get; set; }

        public FormaGeometrica(ShapeType shapeType, decimal lado)
        {
            this.ShapeType = shapeType;
            this.Lado = lado;
        }

        public FormaGeometrica(ShapeType shapeType, decimal lado, decimal altura)
        {
            this.ShapeType = shapeType;
            this.Lado = lado;
            this.Altura = altura;
        }

        public FormaGeometrica(ShapeType shapeType, decimal lado, decimal ladoSuperior, decimal altura)
        {
            this.ShapeType = shapeType;
            this.Lado = lado;
            this.LadoSuperior = ladoSuperior;
            this.Altura = altura;
        }
    }
}
