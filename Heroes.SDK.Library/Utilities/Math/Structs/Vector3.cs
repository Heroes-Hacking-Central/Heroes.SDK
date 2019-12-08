using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.SDK.Utilities.Math.Structs
{
    /// <summary>
    /// Serializable Vector3.
    /// </summary>
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(System.Numerics.Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
