using System.Collections.Generic;

namespace DevelopmentChallenge.Business
{
    public class Factory
    {
        private IDictionary<Entities.ShapeType, IFormaGeometrica> _formasBusiness;

        public Factory()
        {
            this._formasBusiness = new Dictionary<Entities.ShapeType, IFormaGeometrica>
            {
                { Entities.ShapeType.Cuadrado, new Cuadrado() },
                { Entities.ShapeType.Circulo, new Circulo() },
                { Entities.ShapeType.TrianguloEquilatero, new TrianguloEquilatero() },
                { Entities.ShapeType.Rectangulo, new Rectangulo() },
                { Entities.ShapeType.Trapecio, new Trapecio() },
            };
        }

        public IFormaGeometrica GetFormaBusiness(Entities.FormaGeometrica forma)
        {
            IFormaGeometrica formaBusiness = this._formasBusiness[forma.ShapeType];
            formaBusiness.Forma = forma;

            return formaBusiness;
        }
    }
}
