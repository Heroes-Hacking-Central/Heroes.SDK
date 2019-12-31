using System.IO;

namespace Heroes.SDK.Tests.Assets
{
    public static class Assets
    {
        public static byte[] PrimitiveModels = File.ReadAllBytes("Assets/PrimModels.one");
    }
}
