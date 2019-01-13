using System.IO;
using System.Text;

namespace CharacterEncoding
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("Not enough input parameters.");
                return;
            }

            var inputFileName = args[0];

            var outputFileName = args[1];

            var inputFileContent = File.ReadAllText(inputFileName, Encoding.Default);

            CodePageDecoder decoder = new MIKDecoder();

            var decoded = decoder.DecodeFrom(inputFileContent);

            File.WriteAllText(outputFileName, decoded, Encoding.Default);
        }
    }
}
