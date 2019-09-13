using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Heroes.SDK.Utilities.Math
{
    /// <summary>
    /// The CameraVectors class calculates and provides the forward, right and up direction vector for a generic
    /// rotation of the camera.
    /// </summary>
    public struct CameraVectors
    {
        /// <summary>
        /// This is the forward unit vector (Z direction) used for the purpose of navigating through space.
        /// </summary>
        public Vector3 ForwardVector;

        /// <summary>
        /// This is the left unit vector (X direction) used for the purpose of navigating through space.
        /// </summary>
        public Vector3 LeftVector;

        /// <summary>
        /// This is the up unit vector (Y direction) used for the purpose of navigating through space.
        /// </summary>
        public Vector3 UpVector;

        /// <summary>
        /// Calculates the camera X,Y,Z direction vectors from a yaw, pitch and roll.
        /// </summary>
        /// <param name="yawRadians">The direction that moves the camera left and right.</param>
        /// <param name="pitchRadians">The direction that moves the camera up and down.</param>
        /// <param name="rollRadians">Self explanatory.</param>
        public static CameraVectors FromYawPitchRoll(float yawRadians, float pitchRadians, float rollRadians)
        {
            CameraVectors cameraVectors = new CameraVectors();

            var result = Matrix4x4.CreateFromYawPitchRoll(yawRadians, pitchRadians, rollRadians);

            cameraVectors.ForwardVector = Vector3.Transform(new Vector3(0, 0, -1), result); // 0, 0, -1 is forward in right hand system.
            cameraVectors.ForwardVector = Vector3.Normalize(cameraVectors.ForwardVector);

            cameraVectors.LeftVector = Vector3.Transform(new Vector3(-1, 0, 0), result); // Left vector.
            cameraVectors.LeftVector = Vector3.Normalize(cameraVectors.LeftVector);

            cameraVectors.UpVector = Vector3.Transform(Vector3.UnitY, result);
            cameraVectors.UpVector = Vector3.Normalize(cameraVectors.UpVector);

            return cameraVectors;
        }
    }
}
