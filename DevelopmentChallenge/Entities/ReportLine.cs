using System.Collections.Generic;

namespace DevelopmentChallenge.Entities
{
    public class ReportLine
    {
        public IEnumerable<decimal> Areas { get; set; }

        public IEnumerable<decimal> Perimeters { get; set; }

        public ShapeType FormaType { get; set; }
    }
}
