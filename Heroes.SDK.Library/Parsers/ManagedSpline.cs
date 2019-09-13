using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Heroes.SDK.Definitions.Structures.Stage.Splines;
using Reloaded.Messaging.Interfaces;
using Reloaded.Messaging.Interfaces.Message;
using Reloaded.Messaging.Serializer.SystemTextJson;

namespace Heroes.SDK.Parsers
{
    /// <summary>
    /// Represents an individual spline in the format used by the stage injector mod: https://github.com/Sewer56/Heroes.StageInjector.ReloadedII
    /// To Serialize/Deserialize this type, refer to the following guide. https://github.com/Reloaded-Project/Reloaded.Messaging/blob/master/Docs/UseAsSerializationLibrary.md
    /// </summary>
    public class ManagedSpline : ISerializable
    {
        public SplineType SplineType { get; set; }
        public SplineVertex[] Vertices { get; set; }

        public ManagedSpline() { }
        public ManagedSpline(SplineType splineType, SplineVertex[] vertices)
        {
            SplineType = splineType;
            Vertices = vertices;
        }

        // ISerializable
        public ISerializer GetSerializer() => new SystemTextJsonSerializer(new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() },  WriteIndented = true });
        public ICompressor GetCompressor() => null;
        public static ManagedSpline Deserialize(byte[] data) => (ManagedSpline) Serializable.Deserialize<ManagedSpline>(data);
        public static ManagedSpline Deserialize(string filePath) => Deserialize(File.ReadAllBytes(filePath));

    }
}
