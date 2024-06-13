using System;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge
{
    public class FormaGeometrica
    {
        public static string Imprimir(IEnumerable<Entities.FormaGeometrica> formas, Entities.LanguageType idioma)
        {
            var factory = new Business.Factory();
            var report = new Report(idioma);

            if (!formas.Any())
                return report.EmptyList;

            report.AddHeader();

            var areas = new Dictionary<Entities.FormaGeometrica, decimal>();
            var perimetros = new Dictionary<Entities.FormaGeometrica, decimal>();

            foreach (var forma in formas)
            {
                var formaBusiness = factory.GetFormaBusiness(forma);
                decimal area = formaBusiness.CalcularArea();
                decimal perimetro = formaBusiness.CalcularPerimetro();

                areas.Add(forma, area);
                perimetros.Add(forma, perimetro);
            }

            var formaTypes = Enum.GetValues(typeof(Entities.ShapeType)).Cast<Entities.ShapeType>();

            foreach (var formaType in formaTypes)
            {
                var formaTypeAreas = areas.Where(x => x.Key.ShapeType == formaType);
                var formaTypePerimetros = perimetros.Where(x => x.Key.ShapeType == formaType);

                if (!formaTypeAreas.Any())
                    continue;

                var reportLine = new Entities.ReportLine
                {
                    Areas = formaTypeAreas.Select(x => x.Value),
                    Perimeters = formaTypePerimetros.Select(x => x.Value),
                    FormaType = formaType,
                };

                report.AddLine(reportLine);
            }

            var reportFooter = new Entities.ReportFooter
            {
                TotalAmount = formas.Count(),
                TotalArea = areas.Sum(x => x.Value),
                TotalPerimeter = perimetros.Sum(x => x.Value),
            };

            report.AddFooter(reportFooter);

            return report.Get();
        }
    }
}
