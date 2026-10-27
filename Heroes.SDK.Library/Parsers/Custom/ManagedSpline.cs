using Heroes.SDK.Definitions.Structures.Stage.Splines;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Heroes.SDK.Parsers
{
    /// <summary>
    /// Represents an individual spline in the format used by the stage injector mod: https://github.com/Sewer56/Heroes.StageInjector.ReloadedII
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    public class ManagedSpline
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() }, WriteIndented = true };

        public SplineType SplineType { get; set; }
        public SplineVertex[] Vertices { get; set; }

        public ManagedSpline() { }
        public ManagedSpline(SplineType splineType, SplineVertex[] vertices)
        {
            SplineType = splineType;
            Vertices = vertices;
        }

        public static ManagedSpline Deserialize(byte[] data) => JsonSerializer.Deserialize<ManagedSpline>(data, _options);
        public static ManagedSpline Deserialize(string filePath) => Deserialize(File.ReadAllBytes(filePath));

    }
}
