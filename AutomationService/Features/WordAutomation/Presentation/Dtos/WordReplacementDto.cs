namespace AutomationService.Features.WordAutomation.Presentation.Dtos;

public class WordReplacementDto
{
    public string FileName {get; set;}
    public Dictionary<string, string> ReplacePatterns {get; set;}

}