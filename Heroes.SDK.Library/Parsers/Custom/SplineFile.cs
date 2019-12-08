using Heroes.SDK.Parsers;
using SonicHeroes.Utils.StageInjector.Common.Utilities;

namespace SonicHeroes.Utils.StageInjector.Common
{
    public class SplineFile : JsonSerializable<SplineFile>
    {
        public ManagedSpline[] Splines { get; set; }

        public SplineFile() { }
        public SplineFile(ManagedSpline[] splines)
        {
            Splines = splines;
        }
    }
}
