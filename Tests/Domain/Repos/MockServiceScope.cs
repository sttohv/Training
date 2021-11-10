

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Training.Tests.Domain.Repos
{
    public class MockServiceScope : IServiceScope
    {
        public MockServiceScope(IServiceProvider p) => ServiceProvider = p;
        public void Dispose() { }
        public IServiceProvider ServiceProvider { get; }
    }
}
