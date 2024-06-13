using System.Collections.Generic;

namespace DevelopmentChallenge.Texts
{
    public class Shape
    {
        private IDictionary<Entities.ShapeType, string> _singulars;
        private IDictionary<Entities.ShapeType, string> _plurals;

        public Shape(Entities.LanguageType languageType)
        {
            var languageFactory = new LanguageFactory();
            var language = languageFactory.Get(languageType);

            this._singulars = new Dictionary<Entities.ShapeType, string>
            {
                { Entities.ShapeType.Cuadrado, language.Square },
                { Entities.ShapeType.Circulo, language.Circle },
                { Entities.ShapeType.TrianguloEquilatero, language.Triangle },
                { Entities.ShapeType.Rectangulo, language.Rectangle },
                { Entities.ShapeType.Trapecio, language.Trapeze },
            };

            this._plurals = new Dictionary<Entities.ShapeType, string>
            {
                { Entities.ShapeType.Cuadrado, language.Squares },
                { Entities.ShapeType.Circulo, language.Circles },
                { Entities.ShapeType.TrianguloEquilatero, language.Triangles },
                { Entities.ShapeType.Rectangulo, language.Rectangles },
                { Entities.ShapeType.Trapecio, language.Trapezes },
            };
        }

        public string Singular(Entities.ShapeType shapeType) => this._singulars[shapeType];

        public string Plural(Entities.ShapeType shapeType) => this._plurals[shapeType];
    }
}
