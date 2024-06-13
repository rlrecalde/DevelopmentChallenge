using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Test
{
    public class DataTest
    {
        private IDictionary<Entities.LanguageType, Texts.ILanguage> _languages;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this._languages = new Dictionary<Entities.LanguageType, Texts.ILanguage>
            {
                { Entities.LanguageType.Castellano, new Texts.Castellano() },
                { Entities.LanguageType.Ingles, new Texts.Ingles() },
                { Entities.LanguageType.Italiano, new Texts.Italiano() },
            };
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>();
            var idioma = Entities.LanguageType.Castellano;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string expectedReport = language.EmptyList;

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>();
            var idioma = Entities.LanguageType.Ingles;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string expectedReport = language.EmptyList;

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [Test]
        public void TestResumenListaConUnCuadrado()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5) };
            var idioma = Entities.LanguageType.Castellano;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string shapesReport = language.ShapesReport;
            string amount = "1";
            string shape = language.Square;
            string areaLabel = language.Area;
            string areaValue = "25";
            string perimeterLabel = language.Perimeter;
            string perimeterValue = "20";
            string totalText = language.Total;
            string shapesValue = "1";
            string shapesLabel = language.Shapes;

            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", shapesReport);
            string line = Texts.ReportTemplate.Line.Replace("{amount}", amount)
                                                   .Replace("{shape}", shape)
                                                   .Replace("{areaLabel}", areaLabel)
                                                   .Replace("{areaValue}", areaValue)
                                                   .Replace("{perimeterLabel}", perimeterLabel)
                                                   .Replace("{perimeterValue}", perimeterValue);
            string footer = Texts.ReportTemplate.Footer.Replace("{totalText}", totalText)
                                                       .Replace("{shapesValue}", shapesValue)
                                                       .Replace("{shapesLabel}", shapesLabel)
                                                       .Replace("{perimeterLabel}", perimeterLabel)
                                                       .Replace("{perimeterValue}", perimeterValue)
                                                       .Replace("{areaLabel}", areaLabel)
                                                       .Replace("{areaValue}", areaValue);

            string expectedReport = $"{header}{line}{footer}";

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>
            {
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 1),
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 3)
            };
            var idioma = Entities.LanguageType.Ingles;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string shapesReport = language.ShapesReport;
            string amount = "3";
            string shape = language.Squares;
            string areaLabel = language.Area;
            string areaValue = "35";
            string perimeterLabel = language.Perimeter;
            string perimeterValue = "36";
            string totalText = language.Total;
            string shapesValue = "3";
            string shapesLabel = language.Shapes;

            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", shapesReport);
            string line = Texts.ReportTemplate.Line.Replace("{amount}", amount)
                                                   .Replace("{shape}", shape)
                                                   .Replace("{areaLabel}", areaLabel)
                                                   .Replace("{areaValue}", areaValue)
                                                   .Replace("{perimeterLabel}", perimeterLabel)
                                                   .Replace("{perimeterValue}", perimeterValue);
            string footer = Texts.ReportTemplate.Footer.Replace("{totalText}", totalText)
                                                       .Replace("{shapesValue}", shapesValue)
                                                       .Replace("{shapesLabel}", shapesLabel)
                                                       .Replace("{perimeterLabel}", perimeterLabel)
                                                       .Replace("{perimeterValue}", perimeterValue)
                                                       .Replace("{areaLabel}", areaLabel)
                                                       .Replace("{areaValue}", areaValue);

            string expectedReport = $"{header}{line}{footer}";

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>
            {
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4),
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 2),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 9),
                new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4.2m)
            };
            var idioma = Entities.LanguageType.Ingles;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string shapesReport = language.ShapesReport;
            string areaLabel = language.Area;
            string perimeterLabel = language.Perimeter;
            string totalText = language.Total;
            string shapesLabel = language.Shapes;

            string shapeSquares = language.Squares;
            string shapeCircles = language.Circles;
            string shapeTriangles = language.Triangles;

            string amountSquares = "2";
            string areaValueSquares = "29";
            string perimeterValueSquares = "28";
            string amountCircles = "2";
            string areaValueCircles = "13,01";
            string perimeterValueCircles = "18,06";
            string amountTriangles = "3";
            string areaValueTriangles = "49,64";
            string perimeterValueTriangles = "51,6";

            string shapesValue = "7";
            string perimeterValue = "97,66";
            string areaValue = "91,65";

            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", shapesReport);
            string lineSquares = Texts.ReportTemplate.Line.Replace("{amount}", amountSquares)
                                                          .Replace("{shape}", shapeSquares)
                                                          .Replace("{areaLabel}", areaLabel)
                                                          .Replace("{areaValue}", areaValueSquares)
                                                          .Replace("{perimeterLabel}", perimeterLabel)
                                                          .Replace("{perimeterValue}", perimeterValueSquares);
            string lineCircles = Texts.ReportTemplate.Line.Replace("{amount}", amountCircles)
                                                          .Replace("{shape}", shapeCircles)
                                                          .Replace("{areaLabel}", areaLabel)
                                                          .Replace("{areaValue}", areaValueCircles)
                                                          .Replace("{perimeterLabel}", perimeterLabel)
                                                          .Replace("{perimeterValue}", perimeterValueCircles);
            string lineTriangles = Texts.ReportTemplate.Line.Replace("{amount}", amountTriangles)
                                                            .Replace("{shape}", shapeTriangles)
                                                            .Replace("{areaLabel}", areaLabel)
                                                            .Replace("{areaValue}", areaValueTriangles)
                                                            .Replace("{perimeterLabel}", perimeterLabel)
                                                            .Replace("{perimeterValue}", perimeterValueTriangles);
            string footer = Texts.ReportTemplate.Footer.Replace("{totalText}", totalText)
                                                       .Replace("{shapesValue}", shapesValue)
                                                       .Replace("{shapesLabel}", shapesLabel)
                                                       .Replace("{perimeterLabel}", perimeterLabel)
                                                       .Replace("{perimeterValue}", perimeterValue)
                                                       .Replace("{areaLabel}", areaLabel)
                                                       .Replace("{areaValue}", areaValue);

            string expectedReport = $"{header}{lineSquares}{lineCircles}{lineTriangles}{footer}";

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [Test]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>
            {
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4),
                new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 2),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 9),
                new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4.2m)
            };
            var idioma = Entities.LanguageType.Castellano;

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string shapesReport = language.ShapesReport;
            string areaLabel = language.Area;
            string perimeterLabel = language.Perimeter;
            string totalText = language.Total;
            string shapesLabel = language.Shapes;

            string shapeSquares = language.Squares;
            string shapeCircles = language.Circles;
            string shapeTriangles = language.Triangles;

            string amountSquares = "2";
            string areaValueSquares = "29";
            string perimeterValueSquares = "28";
            string amountCircles = "2";
            string areaValueCircles = "13,01";
            string perimeterValueCircles = "18,06";
            string amountTriangles = "3";
            string areaValueTriangles = "49,64";
            string perimeterValueTriangles = "51,6";

            string shapesValue = "7";
            string perimeterValue = "97,66";
            string areaValue = "91,65";

            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", shapesReport);
            string lineSquares = Texts.ReportTemplate.Line.Replace("{amount}", amountSquares)
                                                          .Replace("{shape}", shapeSquares)
                                                          .Replace("{areaLabel}", areaLabel)
                                                          .Replace("{areaValue}", areaValueSquares)
                                                          .Replace("{perimeterLabel}", perimeterLabel)
                                                          .Replace("{perimeterValue}", perimeterValueSquares);
            string lineCircles = Texts.ReportTemplate.Line.Replace("{amount}", amountCircles)
                                                          .Replace("{shape}", shapeCircles)
                                                          .Replace("{areaLabel}", areaLabel)
                                                          .Replace("{areaValue}", areaValueCircles)
                                                          .Replace("{perimeterLabel}", perimeterLabel)
                                                          .Replace("{perimeterValue}", perimeterValueCircles);
            string lineTriangles = Texts.ReportTemplate.Line.Replace("{amount}", amountTriangles)
                                                            .Replace("{shape}", shapeTriangles)
                                                            .Replace("{areaLabel}", areaLabel)
                                                            .Replace("{areaValue}", areaValueTriangles)
                                                            .Replace("{perimeterLabel}", perimeterLabel)
                                                            .Replace("{perimeterValue}", perimeterValueTriangles);
            string footer = Texts.ReportTemplate.Footer.Replace("{totalText}", totalText)
                                                       .Replace("{shapesValue}", shapesValue)
                                                       .Replace("{shapesLabel}", shapesLabel)
                                                       .Replace("{perimeterLabel}", perimeterLabel)
                                                       .Replace("{perimeterValue}", perimeterValue)
                                                       .Replace("{areaLabel}", areaLabel)
                                                       .Replace("{areaValue}", areaValue);

            string expectedReport = $"{header}{lineSquares}{lineCircles}{lineTriangles}{footer}";

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        // Agregados

        [TestCase(Entities.LanguageType.Castellano)]
        [TestCase(Entities.LanguageType.Ingles)]
        [TestCase(Entities.LanguageType.Italiano)]
        public void EmptyList(Entities.LanguageType idioma)
        {
            #region Arrange

            var formas = new List<Entities.FormaGeometrica>();

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string expectedReport = language.EmptyList;

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        [TestCaseSource(nameof(_getCases))]
        public void SeveralReports(Entities.LanguageType idioma, IEnumerable<Entities.FormaGeometrica> formas, IEnumerable<Line> lines, Footer footer)
        {
            #region Arrange

            // From "_getCases".

            #endregion

            #region Act

            string report = FormaGeometrica.Imprimir(formas, idioma);

            #endregion

            #region Assert

            var language = this._languages[idioma];
            string shapesReport = language.ShapesReport;
            string areaLabel = language.Area;
            string perimeterLabel = language.Perimeter;
            string totalText = language.Total;
            string shapesLabel = language.Shapes;

            string header = Texts.ReportTemplate.Header.Replace("{shapesReport}", shapesReport);

            var textLines = new List<string>();
            foreach (var line in lines)
            {
                string textLine = Texts.ReportTemplate.Line.Replace("{amount}", line.Amount)
                                                           .Replace("{shape}", line.Shape)
                                                           .Replace("{areaLabel}", areaLabel)
                                                           .Replace("{areaValue}", line.AreaValue)
                                                           .Replace("{perimeterLabel}", perimeterLabel)
                                                           .Replace("{perimeterValue}", line.PerimeterValue);
                textLines.Add(textLine);
            }
            string concatenatedLines = string.Join("", textLines);

            string textFooter = Texts.ReportTemplate.Footer.Replace("{totalText}", totalText)
                                                           .Replace("{shapesValue}", footer.ShapesValue)
                                                           .Replace("{shapesLabel}", shapesLabel)
                                                           .Replace("{perimeterLabel}", perimeterLabel)
                                                           .Replace("{perimeterValue}", footer.PerimeterValue)
                                                           .Replace("{areaLabel}", areaLabel)
                                                           .Replace("{areaValue}", footer.AreaValue);

            string expectedReport = $"{header}{concatenatedLines}{textFooter}";

            Assert.AreEqual(expectedReport, report);

            #endregion
        }

        private static object[] _getCases =
        {
            // 1 Cuadrado - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Castellano().Square, AreaValue = "25", PerimeterValue = "20" } },
                new Footer { ShapesValue = "1", PerimeterValue = "20", AreaValue = "25" }
            },
            // Muchos Cuadrados - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 1),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 3)
                },
                new List<Line> { new Line { Amount = "3", Shape = new Texts.Castellano().Squares, AreaValue = "35", PerimeterValue = "36" } },
                new Footer { ShapesValue = "3", PerimeterValue = "36", AreaValue = "35" }
            },
            // 1 Círculo - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Castellano().Circle, AreaValue = "7,07", PerimeterValue = "9,42" } },
                new Footer { ShapesValue = "1", PerimeterValue = "9,42", AreaValue = "7,07" }
            },
            // Muchos Círculos - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                },
                new List<Line> { new Line { Amount = "2", Shape = new Texts.Castellano().Circles, AreaValue = "13,01", PerimeterValue = "18,06" } },
                new Footer { ShapesValue = "2", PerimeterValue = "18,06", AreaValue = "13,01" }
            },
            // Muchas Formas - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 2),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 9),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4.2m)
                },
                new List<Line>
                {
                    new Line { Amount = "2", Shape = new Texts.Castellano().Squares, AreaValue = "29", PerimeterValue = "28" },
                    new Line { Amount = "2", Shape = new Texts.Castellano().Circles, AreaValue = "13,01", PerimeterValue = "18,06" },
                    new Line { Amount = "3", Shape = new Texts.Castellano().Triangles, AreaValue = "49,64", PerimeterValue = "51,6" },
                },
                new Footer { ShapesValue = "7", PerimeterValue = "97,66", AreaValue = "91,65" }
            },
            // 1 Cuadrado - Inglés
            new object[]
            {
                Entities.LanguageType.Ingles,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Ingles().Square, AreaValue = "25", PerimeterValue = "20" } },
                new Footer { ShapesValue = "1", PerimeterValue = "20", AreaValue = "25" }
            },
            // Muchos Cuadrados - Inglés
            new object[]
            {
                Entities.LanguageType.Ingles,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 1),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 3)
                },
                new List<Line> { new Line { Amount = "3", Shape = new Texts.Ingles().Squares, AreaValue = "35", PerimeterValue = "36" } },
                new Footer { ShapesValue = "3", PerimeterValue = "36", AreaValue = "35" }
            },
            // 1 Círculo - Inglés
            new object[]
            {
                Entities.LanguageType.Ingles,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Ingles().Circle, AreaValue = "7,07", PerimeterValue = "9,42" } },
                new Footer { ShapesValue = "1", PerimeterValue = "9,42", AreaValue = "7,07" }
            },
            // Muchos Círculos - Inglés
            new object[]
            {
                Entities.LanguageType.Ingles,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                },
                new List<Line> { new Line { Amount = "2", Shape = new Texts.Ingles().Circles, AreaValue = "13,01", PerimeterValue = "18,06" } },
                new Footer { ShapesValue = "2", PerimeterValue = "18,06", AreaValue = "13,01" }
            },
            // Muchas Formas - Inglés
            new object[]
            {
                Entities.LanguageType.Ingles,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 2),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 9),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4.2m)
                },
                new List<Line>
                {
                    new Line { Amount = "2", Shape = new Texts.Ingles().Squares, AreaValue = "29", PerimeterValue = "28" },
                    new Line { Amount = "2", Shape = new Texts.Ingles().Circles, AreaValue = "13,01", PerimeterValue = "18,06" },
                    new Line { Amount = "3", Shape = new Texts.Ingles().Triangles, AreaValue = "49,64", PerimeterValue = "51,6" },
                },
                new Footer { ShapesValue = "7", PerimeterValue = "97,66", AreaValue = "91,65" }
            },
            // 1 Cuadrado - Italiano
            new object[]
            {
                Entities.LanguageType.Italiano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Italiano().Square, AreaValue = "25", PerimeterValue = "20" } },
                new Footer { ShapesValue = "1", PerimeterValue = "20", AreaValue = "25" }
            },
            // Muchos Cuadrados - Italiano
            new object[]
            {
                Entities.LanguageType.Italiano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 1),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 3)
                },
                new List<Line> { new Line { Amount = "3", Shape = new Texts.Italiano().Squares, AreaValue = "35", PerimeterValue = "36" } },
                new Footer { ShapesValue = "3", PerimeterValue = "36", AreaValue = "35" }
            },
            // 1 Círculo - Italiano
            new object[]
            {
                Entities.LanguageType.Italiano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Italiano().Circle, AreaValue = "7,07", PerimeterValue = "9,42" } },
                new Footer { ShapesValue = "1", PerimeterValue = "9,42", AreaValue = "7,07" }
            },
            // Muchos Círculos - Italiano
            new object[]
            {
                Entities.LanguageType.Italiano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                },
                new List<Line> { new Line { Amount = "2", Shape = new Texts.Italiano().Circles, AreaValue = "13,01", PerimeterValue = "18,06" } },
                new Footer { ShapesValue = "2", PerimeterValue = "18,06", AreaValue = "13,01" }
            },
            // Muchas Formas - Italiano
            new object[]
            {
                Entities.LanguageType.Italiano,
                new List<Entities.FormaGeometrica>
                {
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 5),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 3),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4),
                    new Entities.FormaGeometrica(Entities.ShapeType.Cuadrado, 2),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 9),
                    new Entities.FormaGeometrica(Entities.ShapeType.Circulo, 2.75m),
                    new Entities.FormaGeometrica(Entities.ShapeType.TrianguloEquilatero, 4.2m)
                },
                new List<Line>
                {
                    new Line { Amount = "2", Shape = new Texts.Italiano().Squares, AreaValue = "29", PerimeterValue = "28" },
                    new Line { Amount = "2", Shape = new Texts.Italiano().Circles, AreaValue = "13,01", PerimeterValue = "18,06" },
                    new Line { Amount = "3", Shape = new Texts.Italiano().Triangles, AreaValue = "49,64", PerimeterValue = "51,6" },
                },
                new Footer { ShapesValue = "7", PerimeterValue = "97,66", AreaValue = "91,65" }
            },
            // 1 Rectángulo - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Rectangulo, 5, 3) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Castellano().Rectangle, AreaValue = "15", PerimeterValue = "16" } },
                new Footer { ShapesValue = "1", PerimeterValue = "16", AreaValue = "15" }
            },
            // 1 Trapecio - Castellano
            new object[]
            {
                Entities.LanguageType.Castellano,
                new List<Entities.FormaGeometrica> { new Entities.FormaGeometrica(Entities.ShapeType.Trapecio, 10, 2, 3) },
                new List<Line> { new Line { Amount = "1", Shape = new Texts.Castellano().Trapeze, AreaValue = "18", PerimeterValue = "22" } },
                new Footer { ShapesValue = "1", PerimeterValue = "22", AreaValue = "18" }
            },
        };

        public class Line
        {
            public string Amount { get; set; }

            public string Shape { get; set; }

            public string AreaValue { get; set; }

            public string PerimeterValue { get; set; }
        }

        public class Footer
        {
            public string ShapesValue { get; set; }

            public string PerimeterValue { get; set; }

            public string AreaValue { get; set; }
        }
    }
}