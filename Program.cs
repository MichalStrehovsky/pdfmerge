using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

var outFileName = "out.pdf";
var outputDocument = new PdfDocument();

int mergedFiles = args.Length;
for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "--out")
    {
        if (++i == args.Length)
            return ErrorExit("`--out` must be followed by the output file name");

        outFileName = args[i++];
        mergedFiles -= 2;
        continue;
    }

    try
    {
        using PdfDocument doc = PdfReader.Open(args[i], PdfDocumentOpenMode.Import);

        foreach (PdfPage page in doc.Pages)
            outputDocument.AddPage(page);
    }
    catch (Exception ex)
    {
        return ErrorExit($"Failed processing {args[i]}: {ex.Message}");
    }
}

if (mergedFiles < 2)
    return ErrorExit("Must specify at least two files to merge");

outputDocument.Save(outFileName);

Console.WriteLine($"Merged PDF is available at {outFileName}");

return 0;

static int ErrorExit(string errorString)
{
    Console.WriteLine($"Error: {errorString}");
    Console.WriteLine();
    Console.WriteLine("Usage: pdfmerge file1.pdf file2.pdf [file3.pdf...] [--out output.pdf]");
    Console.WriteLine("If --out is not specified, output is saved into out.pdf in the current directory.");
    return 1;
}
