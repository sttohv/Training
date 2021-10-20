using System;
using Microsoft.Extensions.DependencyInjection;

namespace Training.Domain.Common
{
    public sealed class GetRepo
    {
        internal readonly IServiceProvider provider;
        internal static IServiceProvider instance;
        public GetRepo() : this(null) { }
        public GetRepo(IServiceProvider p) => provider = p ?? instance;
        public static void SetProvider(IServiceProvider p) => instance = p;
        public dynamic Instance(Type t)
        {
            var p = provider;
            var c = p?.CreateScope();
            var s = c?.ServiceProvider;
            var r = s?.GetService(t);
            return r;
        }
        public TService Instance<TService>() => (TService)Instance(typeof(TService));
    }
}
