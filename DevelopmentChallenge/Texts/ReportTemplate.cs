namespace DevelopmentChallenge.Texts
{
    public class ReportTemplate
    {
        public static string Header => "<h1>{shapesReport}</h1>";
        public static string Line => "{amount} {shape} | {areaLabel} {areaValue} | {perimeterLabel} {perimeterValue} <br/>";
        public static string Footer => "{totalText}:<br/>{shapesValue} {shapesLabel} {perimeterLabel} {perimeterValue} {areaLabel} {areaValue}";
    }
}
