using System.Reflection;
using System.Text.RegularExpressions;
using AutomationService.Features.WordAutomation.Presentation.Dtos;
using Xceed.Document.NET;
using Xceed.Drawing;
using Xceed.Words.NET;

namespace AutomationService.Features.WordAutomation.Domain.Services;

public class WordAutomationService() : IWordAutomationService
{
    public void GenerateReplacedDocument(WordReplacementDto replacementDto)
    {
        var replacePatterns = new Dictionary<string, string>(
                replacementDto.ReplacePatterns,
                StringComparer.OrdinalIgnoreCase) // Ignoriert Groß-/Kleinschreibung
            {
                { "Today", DateTime.Today.ToShortDateString() }
            };
        // Load a document.
        using (var document = DocX.Load(replacementDto.FileName + ".docx"))
        {
            if (document == null)
            {
                throw new FileNotFoundException($"The file {replacementDto.FileName}.docx could not be found");
            }

            // Check if all the replace patterns are used in the loaded document.
            if (document.FindUniqueByPattern(@"\{\{(.*?)\}\}", RegexOptions.IgnoreCase).Count > 0)
            {
                // Do the replacement of all the found tags and with green bold strings.
                var replaceTextOptions = new FunctionReplaceTextOptions()
                {
                    FindPattern = @"\{\{(.*?)\}\}",
                    RegExOptions = RegexOptions.IgnoreCase,
                    NewFormatting = new Formatting() { Bold = true, FontColor = Color.Green },
                    RegexMatchHandler = (findStr) =>
                    {
                        Console.WriteLine($"Findstr : {findStr}");

                        if (replacePatterns.TryGetValue(findStr, out var match))
                        {
                            return match;
                        }

                        return $"{{{{{findStr}}}}}";
                    }
                };
                document.ReplaceText(replaceTextOptions);
                // Save this document to disk.
                // Use a custom format like HH-mm-ss or HH_mm_ss
                string timestamp = DateTime.Now.ToString("HH-mm-ss");
                string date = DateTime.Now.ToShortDateString();
                document.SaveAs($"{replacementDto.FileName}_{date}_gen.docx");
            }
        }
    }
}