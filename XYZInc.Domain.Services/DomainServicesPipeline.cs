using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using XYZInc.Domain.Services;
using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Infra.Security
{
    [ExcludeFromCodeCoverage]
    public static class DomainServicesPipeline
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IOrderProcessor, MastercardProcessor>();
            services.AddSingleton<IOrderProcessor, VisaProcessor>();
            services.AddSingleton<IOrderProcessor, UndefinedProcessor>();
            services.AddSingleton<IProcessorFactory, ProcessorFactory>();
        }
    }
}
