using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Heroes.SDK.Utilities.Math;
using Vector3 = System.Numerics.Vector3;

namespace Heroes.SDK.Definitions.Structures.World.Camera
{
    [Equals(DoNotAddEqualityOperators =true)]
    [StructLayout(LayoutKind.Sequential, Size = 0x2324)] // The size is not a typo. Verified in PC AND PS2 Disassembly
    public struct HeroesCamera
    {
        /// <summary>
        /// The position of the camera.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// The rotation of the camera.
        /// </summary>
        public HeroesCameraRotation Rotation;

        private int _float18;
        private int _float1C;
        private int _float20;

        /// <summary>
        /// The position the camera is currently looking at.
        /// </summary>
        public Vector3 LookAt;

        /* Methods */

        /// <summary>
        /// Rotates the camera to the specified X, Y, Z angles in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        public void SetRotation(Vector3 vector) => SetRotation(ref vector);

        /// <summary>
        /// Rotates the camera to the specified X, Y, Z angles in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        public void SetRotation(ref Vector3 vector) => Rotation.SetRotation(ref vector);

        /// <summary>
        /// Rotates the camera by an absolute offset X, Y, Z in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        /// <param name="transformMode">Whether the current rotation should be used or ignored during rotation. See <see cref="Transform"/></param>
        /// <param name="invertOnUpsideDown">
        ///     Inverts horizontal movement when the camera is upside down.
        ///     Set this to true if a user/human is controlling the camera, else left and right will swap upside-down.
        /// </param>
        public void RotateBy(Vector3 vector, Transform transformMode = Transform.Relative, bool invertOnUpsideDown = false) => Rotation.RotateBy(ref vector, transformMode, invertOnUpsideDown);

        /// <summary>
        /// Rotates the camera by an absolute offset X, Y, Z in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        /// <param name="transformMode">Whether the current rotation should be used or ignored during rotation. See <see cref="Transform"/></param>
        /// <param name="invertOnUpsideDown">
        ///     Inverts horizontal movement when the camera is upside down.
        ///     Set this to true if a user/human is controlling the camera, else left and right will swap upside-down.
        /// </param>
        public void RotateBy(ref Vector3 vector, Transform transformMode = Transform.Relative, bool invertOnUpsideDown = false) => Rotation.RotateBy(ref vector, transformMode, invertOnUpsideDown);

        /// <summary>
        /// Moves the camera by an absolute offset specified by the passed in vector.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        /// <param name="transformMode">Whether the current rotation should be used or ignored during rotation. See <see cref="Transform"/></param>
        public void MoveBy(Vector3 vector, Transform transformMode = Transform.Relative) => MoveBy(ref vector, transformMode);

        /// <summary>
        /// Moves the camera by an absolute offset specified by the passed in vector.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        /// <param name="transformMode">Whether the current rotation should be used or ignored during rotation. See <see cref="Transform"/></param>
        public void MoveBy(ref Vector3 vector, Transform transformMode = Transform.Relative)
        {
            if (transformMode == Transform.Relative)
            {
                var vectors    = GetCameraVectors();
                Position       += vectors.LeftVector * vector.X;
                Position       += vectors.UpVector * vector.Y;
                Position       += vectors.ForwardVector * vector.Z;
            }
            else if (transformMode == Transform.Absolute)
            {
                Position.X += vector.X;
                Position.Y += vector.Y;
                Position.Z += vector.Z;
            }
        }

        // Utility Methods

        /// <summary>
        /// Returns the forward, left and up unit vectors based off of the current rotation of the camera. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CameraVectors GetCameraVectors()
        {
            Rotation.AsRadians(out var radians);
            return CameraVectors.FromYawPitchRoll(radians.X, radians.Y, radians.Z);
        }
    }
}
