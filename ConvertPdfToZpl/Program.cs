using PDFtoZPL;
using System;
using System.IO;

namespace ConvertPdfToZpl
{
    internal class Program
    {
        //Execute single file: dotnet publish -r win-x86 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
        static void Main(string[] args)
        {
            if (args?.Length == 0)
                return;

            string filePath = args[0];
            string fileName = $"{Path.GetFileNameWithoutExtension(filePath)}.zpl";

            Console.WriteLine($"Converting to zpl -> {fileName}");

            try
            {
                byte[] file = File.ReadAllBytes(filePath);
                string zpl = Conversion.ConvertPdfPage(file, dpi: 300);
                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName), zpl);
            }
            catch
            {
                Console.WriteLine("Convert failed.");
            }
        }
    }
}
