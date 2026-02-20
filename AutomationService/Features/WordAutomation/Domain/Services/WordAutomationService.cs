using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using AutomationService.Features.WordAutomation.Presentation.Dtos;

namespace AutomationService.Features.WordAutomation.Domain.Services;

public class WordAutomationService() : IWordAutomationService
{
    public string TestMethod(WordReplacementDto wordReplacementDto)
    {
        string template = "Sehr geehrter Herr {{LastName}}\n,Das hier Ist Mein Brief, den ich am {{Date}} schreibe.Die {{InsuranceName}} hat mir geschrieben, dass sie bald nicht mehr da sein werden.";
        string generatedText = template;

        wordReplacementDto.Date = DateTime.Now.Date.ToShortDateString();
        PropertyInfo[] propertyInfos = typeof(WordReplacementDto).GetProperties();
        foreach (var property in propertyInfos)
        {
            var value = property.GetValue(wordReplacementDto)?.ToString() ?? "";
             generatedText = generatedText.Replace($"{{{{{property.Name}}}}}", value);
            
        }
        return $"Text Vorher:\n {template}\n \nGenerierter Text:\n {generatedText}";
    }
}