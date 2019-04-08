namespace ReportWebJob
{
    using System;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.DependencyInjection;

    internal class JobDependenciesActivator : IJobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public JobDependenciesActivator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public TService CreateInstance<TService>() => _serviceProvider.GetService<TService>();
    }
}