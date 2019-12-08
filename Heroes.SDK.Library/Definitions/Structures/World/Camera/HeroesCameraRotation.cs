using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Heroes.SDK.Definitions.Structures.World.Camera
{
    [Equals(DoNotAddEqualityOperators =true)]
    public struct HeroesCameraRotation
    {
        private const float MaxAngleDegrees = 360F;
        private const float DoublePi = (float) (Math.PI * 2);
        private const ushort UpsideDownMax = (ushort) (3/4F * ushort.MaxValue);
        private const ushort UpsideDownMin = (ushort) (1/4F * ushort.MaxValue);

        private uint _angleVerticalBams;
        private uint _angleHorizontalBams;
        private uint _angleRollBams;

        /// <summary>
        /// Gets or sets the rotation of the camera in degrees.
        /// The X component corresponds to horizontal rotation, Y to vertical and Z to roll.
        /// </summary>
        public Vector3 Rotation
        {
            get => new Vector3(RotationHorizontal, RotationVertical, RotationRoll);
            set
            {
                RotationHorizontal = value.X;
                RotationVertical = value.Y;
                RotationRoll = value.Z;
            }
        }

        /// <summary>
        /// Gets or sets the horizontal rotation of the camera in degrees. (a.k.a. the Yaw) 
        /// </summary>
        public float RotationHorizontal
        {
            get => BAMSToDegrees(_angleHorizontalBams);
            set => _angleHorizontalBams = DegreesToBAMS(value);
        }

        /// <summary>
        /// Gets or sets the the vertical rotation of the camera in degrees. (a.k.a. the Pitch)
        /// </summary>
        public float RotationVertical
        {
            // Do not allow camera to go beyond 90 degrees.
            // We have roll if we want to go up-side down.

            get => BAMSToDegrees(_angleVerticalBams);
            set => _angleVerticalBams = DegreesToBAMS(value);
        }

        /// <summary>
        /// Gets or sets the roll of the camera, in degrees.
        /// </summary>
        public float RotationRoll
        {
            get => BAMSToDegrees(_angleRollBams);
            set => _angleRollBams = DegreesToBAMS(value);
        }

        /* Methods */

        /// <summary>
        /// Rotates the camera to the specified X, Y, Z angles in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        public void SetRotation(ref Vector3 vector)
        {
            RotationHorizontal = vector.X;
            RotationVertical = vector.Y;
            RotationRoll = vector.Z;
        }

        /// <summary>
        /// Rotates the camera by an absolute offset X, Y, Z in degrees.
        /// </summary>
        /// <param name="vector">X, Y, Z coordinates to move by.</param>
        /// <param name="transformMode">Whether the current rotation should be used or ignored during rotation. See <see cref="Transform"/></param>
        /// <param name="invertOnUpsideDown">
        ///     Inverts horizontal movement when the camera is upside down.
        ///     Set this to true if a user/human is controlling the camera, else left and right will swap upside-down.
        /// </param>
        public void RotateBy(ref Vector3 vector, Transform transformMode = Transform.Relative, bool invertOnUpsideDown = false)
        {
            if (transformMode == Transform.Relative)
            {
                // Transform.
                var rotationMatrix = Matrix4x4.CreateRotationZ(BAMSToRadians(_angleRollBams));
                var rotationVector = Vector3.Transform(new Vector3(vector.X, vector.Y, 0), rotationMatrix);

                if (invertOnUpsideDown && IsUpsideDown())
                    rotationVector.X *= -1;

                RotationVertical   += rotationVector.Y;
                RotationHorizontal += rotationVector.X;
                RotationRoll       += vector.Z;
            }
            else if (transformMode == Transform.Absolute)
            {
                RotationHorizontal += vector.X;
                RotationVertical += vector.Y;
                RotationRoll += vector.Z;
            }
        }

        /// <summary>
        /// Returns true if the camera is up-side down. i.e. Vertical angle is between 90 and 270 degrees.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsUpsideDown()
        {
            return IsBetween(UpsideDownMin, UpsideDownMax, _angleVerticalBams);
        }

        /* Utilities */

        /// <summary>
        /// Returns the current rotation as a set of angles X, Y, Z in radians.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AsRadians(out Vector3 radians)
        {
            radians = new Vector3(BAMSToRadians(_angleHorizontalBams), BAMSToRadians(_angleVerticalBams), BAMSToRadians(_angleRollBams));
        }

        /* Helpers */
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsBetween(float x, float y, float value)
        {
            return (x <= value && value <= y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float BAMSToRadians(uint bams) => (float)((bams % ushort.MaxValue) / (float) ushort.MaxValue * DoublePi);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint DegreesToBAMS(float degrees) => (uint)((degrees % MaxAngleDegrees) / MaxAngleDegrees * ushort.MaxValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float BAMSToDegrees(uint bams) => ((bams % ushort.MaxValue) / (float) ushort.MaxValue) * MaxAngleDegrees;
    }
}