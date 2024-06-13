using System.Linq;
using System.Text;

namespace DevelopmentChallenge
{
    public class Report
    {
        private StringBuilder _stringBuilder;
        private Texts.Text _text;
        private Texts.Shape _shape;

        public Report(Entities.LanguageType languageType)
        {
            this._stringBuilder = new StringBuilder();
            this._text = new Texts.Text(languageType);
            this._shape = new Texts.Shape(languageType);
        }

        public string EmptyList => this._text.EmptyList;

        public void AddHeader()
        {
            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", this._text.ShapesReport);
            
            this._stringBuilder.Append(header);
        }

        public void AddLine(Entities.ReportLine reportLine)
        {
            decimal area = reportLine.Areas.Sum();
            decimal perimetro = reportLine.Perimeters.Sum();
            int cantidad = reportLine.Areas.Count();

            string formattedShape = cantidad == 1 ? this._shape.Singular(reportLine.FormaType) : this._shape.Plural(reportLine.FormaType);

            string line = Texts.ReportTemplate.Line.Replace("{amount}", cantidad.ToString())
                                                   .Replace("{shape}", formattedShape)
                                                   .Replace("{areaLabel}", this._text.Area)
                                                   .Replace("{areaValue}", area.ToString("#.##"))
                                                   .Replace("{perimeterLabel}", this._text.Perimeter)
                                                   .Replace("{perimeterValue}", perimetro.ToString("#.##"));

            this._stringBuilder.Append(line);
        }

        public void AddFooter(Entities.ReportFooter reportFooter)
        {
            string footer = Texts.ReportTemplate.Footer.Replace("{totalText}", this._text.Total)
                                                       .Replace("{shapesValue}", reportFooter.TotalAmount.ToString())
                                                       .Replace("{shapesLabel}", this._text.Shapes)
                                                       .Replace("{perimeterLabel}", this._text.Perimeter)
                                                       .Replace("{perimeterValue}", reportFooter.TotalPerimeter.ToString("#.##"))
                                                       .Replace("{areaLabel}", this._text.Area)
                                                       .Replace("{areaValue}", reportFooter.TotalArea.ToString("#.##"));

            this._stringBuilder.Append(footer);
        }

        public string Get()
        {
            return this._stringBuilder.ToString();
        }
    }
}
