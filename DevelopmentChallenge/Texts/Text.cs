namespace DevelopmentChallenge.Texts
{
    public class Text
    {
        private Entities.LanguageType _languageType;
        private LanguageFactory _language;

        public Text(Entities.LanguageType languageType)
        {
            this._languageType = languageType;
            this._language = new LanguageFactory();
        }

        public string EmptyList => this._language.Get(this._languageType).EmptyList;
        public string ShapesReport => this._language.Get(this._languageType).ShapesReport;
        public string Total => this._language.Get(this._languageType).Total;
        public string Shapes => this._language.Get(this._languageType).Shapes;
        public string Perimeter => this._language.Get(this._languageType).Perimeter;
        public string Area => this._language.Get(this._languageType).Area;
        public string Square => this._language.Get(this._languageType).Square;
        public string Circle => this._language.Get(this._languageType).Circle;
        public string Triangle => this._language.Get(this._languageType).Triangle;
        public string Squares => this._language.Get(this._languageType).Squares;
        public string Circles => this._language.Get(this._languageType).Circles;
        public string Triangles => this._language.Get(this._languageType).Triangles;
        public string Rectangle => this._language.Get(this._languageType).Rectangle;
        public string Rectangles => this._language.Get(this._languageType).Rectangles;
        public string Trapeze => this._language.Get(this._languageType).Trapeze;
        public string Trapezes => this._language.Get(this._languageType).Trapezes;
    }
}
