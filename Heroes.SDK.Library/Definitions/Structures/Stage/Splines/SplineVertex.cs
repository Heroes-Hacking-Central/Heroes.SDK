using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Heroes.SDK.Definitions.Structures.Stage.Splines
{
    /// <summary>
    /// Represents an individual vertex of a SADX/SA2/Heroes spline.
    /// </summary>
    [Equals(DoNotAddEqualityOperators =true)]
    public struct SplineVertex
    {
        /// <summary>
        /// BAMS 0 - 65535. Pitch is clockwise, i.e. rotating 90 degrees causes the characters' legs to point AWAY from the camera.
        /// </summary>
        public ushort Pitch { get; set; }

        /// <summary>
        /// BAMS 0 - 65535. Roll is anticlockwise, i.e. to the left.
        /// Values between 25% and 75% will cause the characters to land backwards on rails.
        /// </summary>
        public ushort Roll { get; set; }

        /// <summary>
        /// Calculated through taking away the XYZ postion of the next vector with the current vector and then
        /// performing an addition of the squared XYZ components and taking the square root.
        /// See <see cref="GetDistance(Heroes.SDK.Definitions.Structures.Stage.Splines.SplineVertex)"/>
        /// e.g. sqrt((X1 - X2)^2 + (Y1 - Y2)^2 + (Z1 - Z2)^2)
        /// </summary>
        public float DistanceToNextVertex { get; set; }

        /// <summary>
        /// Used for serialization only.
        /// </summary>
        public Utilities.Math.Structs.Vector3 Position => new Utilities.Math.Structs.Vector3(ActualPosition);

        /// <summary>
        /// Represents the position of the spline's vertex in 3D space.
        /// </summary>
        [JsonIgnore]
        private Vector3 ActualPosition { get; set; }

        public SplineVertex(float x, float y, float z) : this(new Vector3(x, y, z)) { }

        /// <summary>
        /// Creates an instance of a vertex from a mutually predefined position.
        /// </summary>
        public SplineVertex(Vector3 position)
        {
            this.ActualPosition = position;
            DistanceToNextVertex = 0;

            Pitch = 0;
            Roll = 0;
        }

        /// <summary>
        /// Creates an instance of a vertex given a position and the remaining properties.
        /// </summary>
        public SplineVertex(int unknownRotation, Vector3 position)
        {
            DistanceToNextVertex = 0;
            ActualPosition = position;

            Pitch = 0;
            Roll = 0;
        }

        /// <summary>
        /// Obtains the distance between two vertices.
        /// </summary>
        /// <param name="other">The other vertex.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetDistance(SplineVertex other)
        {
            return Vector3.Distance(ActualPosition, other.ActualPosition);
        }

        /// <summary>
        /// Obtains the distance between two spline vertices.
        /// </summary>
        /// <param name="other">The other vertex.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short GetPitch(SplineVertex other)
        {
            float differenceX = ActualPosition.X - other.ActualPosition.X;
            float differenceZ = ActualPosition.Z - other.ActualPosition.Z;
            double adjacent   = Math.Sqrt(Math.Pow(differenceX, 2) + Math.Pow(differenceZ, 2));

            // Use Pythagoras to get angle between hypotenuse and Y.
            float opposite = ActualPosition.Y - other.ActualPosition.Y;

            // Calculate angle.
            double tan   = opposite / adjacent;
            double angle = Math.Tanh(tan);

            // (angle / (2 * Math.PI)) gets a decimal e.g. 0.20 where 1 is 100%
            double decimalAngle = (angle / (2 * Math.PI));
            return (short)(decimalAngle * short.MaxValue * -1); // Pitch direction in Heroes is opposite.
        }
    }
}
