namespace Heroes.SDK.Definitions.Structures.Collision.Stage
{
    [Equals(DoNotAddEqualityOperators = true)]
    public struct TriangleCollisionProperties
    {
        public static TriangleCollisionProperties Floor => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x00);
        public static TriangleCollisionProperties FloorOffroad => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x01);
        public static TriangleCollisionProperties FloorWater => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x02);

        public static TriangleCollisionProperties FloorSand => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x10);
        public static TriangleCollisionProperties FloorGrass => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x20);
        public static TriangleCollisionProperties FloorRock => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0, 0x80);

        public static TriangleCollisionProperties Wall => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0x01, 0);
        public static TriangleCollisionProperties WallRock => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0x01, 0x80);
        public static TriangleCollisionProperties FloorStaircase => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0x04, 0);
        public static TriangleCollisionProperties WallInvisibleBarrier => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0, 0x80, 0);

        public static TriangleCollisionProperties Death => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0x01, 0, 0);
        public static TriangleCollisionProperties WallBingo => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0x04, 0, 0x80);
        public static TriangleCollisionProperties WallIncline => new TriangleCollisionProperties(TriangleCollisionFlag.None, 0x08, 0, 0);

        public static TriangleCollisionProperties Bingo => new TriangleCollisionProperties(TriangleCollisionFlag.Bingo, 0, 0, 0);
        public static TriangleCollisionProperties Pinball => new TriangleCollisionProperties(TriangleCollisionFlag.Pinball, 0, 0, 0);

        /// <summary>
        /// Special flag for this collision file.
        /// </summary>
        public TriangleCollisionFlag Flag;

        /// <summary>
        /// Amount this floor restricts your momentum while moving forward.
        /// </summary>
        public byte HorizontalPushback;

        /// <summary>
        /// Amount this floor restricts your momentum while moving upward.
        /// </summary>
        public byte VerticalPushback;

        /// <summary>
        /// Amount this floor restricts your momentum while moving sideways.
        /// </summary>
        public byte ForwardPushback;

        public TriangleCollisionProperties(TriangleCollisionFlag flag, byte horizontalPushback, byte verticalPushback, byte forwardPushback)
        {
            Flag = flag;
            ForwardPushback = forwardPushback;
            VerticalPushback = verticalPushback;
            HorizontalPushback = horizontalPushback;
        }
    }
}
