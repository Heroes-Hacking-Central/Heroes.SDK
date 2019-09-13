using System;
using Heroes.SDK.Parsers;
using Reloaded.Memory;
using Reloaded.Memory.Sources;

namespace Heroes.SDK.Definitions.Structures.Stage.Splines
{
    /// <summary>
    /// Struct that defines a spline header.
    /// </summary>
    public unsafe struct Spline : IDisposable
    {
        /// <summary>
        /// Always 1
        /// </summary>
        public ushort Enabler;

        /// <summary>
        /// Amount of vertices in spline
        /// </summary>
        public ushort NumberOfVertices;

        /// <summary>
        /// Purpose Unknown, Set 1000F
        /// </summary>
        public float TotalSplineLength;

        /// <summary>
        /// Points to the vertex list for the current individual spline.
        /// </summary>
        public SplineVertex* VertexList;

        /// <summary>
        /// Note: This is a function pointer to the function to handle current spline's behaviour.
        /// </summary>
        public SplineType SplineType;

        /// <summary>
        /// Creates a <see cref="Spline"/> given a deserialized spline file.
        /// </summary>
        public Spline(ManagedSpline managedSpline)
        {
            Enabler = 1;
            TotalSplineLength = 0;
            NumberOfVertices = 0;
            VertexList = (SplineVertex*)0;
            SplineType = SplineType.Loop;

            FromSplineJson(managedSpline);
        }

        private void FromSplineJson(ManagedSpline managedSpline)
        {
            SplineType = managedSpline.SplineType;
            NumberOfVertices = (ushort)managedSpline.Vertices.Length;

            foreach (var vertex in managedSpline.Vertices)
                TotalSplineLength += vertex.DistanceToNextVertex;

            CopyVertices(managedSpline);
        }

        public void Dispose()
        {
            var memory = Memory.Instance;
            memory.Free((IntPtr)VertexList);
        }

        /* Construction Helpers */

        private void CopyVertices(ManagedSpline managedSpline)
        {
            var memory = Memory.Instance;
            var vertices = managedSpline.Vertices;

            int structSize = StructArray.GetSize<SplineVertex>(vertices.Length);
            VertexList = (SplineVertex*)memory.Allocate(structSize);
            StructArray.ToPtr((IntPtr)VertexList, vertices);
        }
    }
}
