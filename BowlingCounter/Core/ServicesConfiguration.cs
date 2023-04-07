using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServicesConfiguration
{
    public static IServiceCollection AddBowlingCounterServices(this IServiceCollection services)
    {
        services.AddTransient<IFrameThrowResultFactory, FrameThrowResultFactory>();
        services.AddTransient<IFrameWithConsecutiveFramesFactory, FrameWithConsecutiveFramesFactory>();
        services.AddTransient<IFrameScoreResultFactory, FrameScoreResultFactory>();
        services.AddTransient<IBowlingScoreFactory, BowlingScoreFactory>();
        return services;
    }
}