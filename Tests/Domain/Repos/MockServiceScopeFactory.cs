using Microsoft.Extensions.DependencyInjection;
using System;

namespace Training.Tests.Domain.Repos
{
    public class MockServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IServiceProvider provider;
        public MockServiceScopeFactory(IServiceProvider p) => provider = p;

        public IServiceScope CreateScope() => new MockServiceScope(provider);
    }
}
