using AutomationService.Features.WordAutomation.Domain.Services;
using AutomationService.Features.WordAutomation.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AutomationService.Features.WordAutomation.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class WordAutomationController(IWordAutomationService wordAutomationService) : ControllerBase
{
    [HttpPost]
    public IActionResult ReplaceWords([FromBody]WordReplacementDto wordReplacementDto)
    {

        var result = wordAutomationService.TestMethod(wordReplacementDto);

        return Ok(result);
    }
}
