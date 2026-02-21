using AutomationService.Features.WordAutomation.Domain.Services;
using AutomationService.Features.WordAutomation.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomationService.Features.WordAutomation.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class WordAutomationController(IWordAutomationService wordAutomationService) : ControllerBase
{
    [HttpPost]
    [Route("replaced-document")]
    public IActionResult GenerateReplacedDocument([FromBody] WordReplacementDto wordReplacementDto)
    {
        wordAutomationService.GenerateReplacedDocument(wordReplacementDto);
        return Ok(true);
    }
}