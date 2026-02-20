using AutomationService.Features.WordAutomation.Domain.Services;

namespace AutomationService.Features.WordAutomation.Presentation.DependencyInjection;

public static class WodAutomationInjection
{
    public static IServiceCollection AddWordServices(this IServiceCollection services)
    {
        services.AddScoped<IWordAutomationService,WordAutomationService>();

        return services;
    }
}