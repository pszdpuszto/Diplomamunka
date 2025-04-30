namespace UniversalForms.TestUtils
{
    public static class FileUtil
    {
        public const string TestPath = "Test";
        public const string InputPath = $"{TestPath}/Input";
        public const string ReferencePath = $"{TestPath}/Reference";
        public const string outputPath = $"{TestPath}/Output";
        public static bool CompareFiles(string fileName)
        {
            var outputFile = Path.Join(outputPath, fileName);
            var referenceFile = Path.Join(ReferencePath, fileName);
            if (!File.Exists(outputFile) || !File.Exists(referenceFile))
                return false;
            var outputFileLines = File.ReadAllLines(outputFile);
            var referenceFileLines = File.ReadAllLines(referenceFile);
            if (outputFileLines.Length != referenceFileLines.Length)
                return false;
            for (int i = 0; i < outputFileLines.Length; i++)
            {
                if (outputFileLines[i] != referenceFileLines[i])
                    return false;
            }
            return true;
        }
        public static bool CompareToFile(string str, string fileName)
        {
            var referenceFile = Path.Join(ReferencePath, fileName + ".string");
            if (!File.Exists(referenceFile))
                return false;
            var referenceFileText = File.ReadAllText(referenceFile);
            return str == referenceFileText;
        }
        public static string ReadInputFile(string fileName)
        {
            var filePath = Path.Join(InputPath, fileName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            return File.ReadAllText(filePath);
        }
    }
}
