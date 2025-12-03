using Heroes.SDK.Parsers;
using Xunit;

namespace Heroes.SDK.Tests
{
    public class OneArchiveParserTests
    {
        [Fact]
        public void GetsCorrectNumberOfFiles()
        {
            var oneArchive = new OneArchive(Assets.Assets.PrimitiveModels);
            Assert.Equal(17, oneArchive.GetNumberOfFiles());
        }

        [Fact]
        public void CanDecompressAndRecompress()
        {
            SDK.Init(null, new csharp_prs.PrsInstance());

            var oneArchive = new OneArchive(Assets.Assets.PrimitiveModels);
            var files = oneArchive.GetFiles();

            var newArchiveData = OneArchive.FromFiles(files, 255);
            var newArchive = new OneArchive(newArchiveData);
            var newFiles = newArchive.GetFiles();

            Assert.Equal(files.Count, newFiles.Count);
            for (int x = 0; x < files.Count; x++)
            {
                var oldFile = files[x];
                var newFile = newFiles[x];
                Assert.Equal(oldFile.GetUncompressedData(), newFile.GetUncompressedData());
            }
        }
    }
}
