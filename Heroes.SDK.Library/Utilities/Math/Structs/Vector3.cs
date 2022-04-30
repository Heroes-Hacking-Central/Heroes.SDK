using Heroes.SDK.Utilities.Misc;

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

        public static implicit operator Vector3(System.Numerics.Vector3 vector3) => vector3.ReinterpretCast<System.Numerics.Vector3, Vector3>();
        public static implicit operator System.Numerics.Vector3(Vector3 vector3) => vector3.ReinterpretCast<Vector3, System.Numerics.Vector3>();
    }
}
