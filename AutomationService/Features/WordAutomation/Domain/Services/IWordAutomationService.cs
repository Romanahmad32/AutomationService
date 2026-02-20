using AutomationService.Features.WordAutomation.Presentation.Dtos;

namespace AutomationService.Features.WordAutomation.Domain.Services;

public interface IWordAutomationService
{
    string TestMethod(WordReplacementDto wordReplacementDto);
}