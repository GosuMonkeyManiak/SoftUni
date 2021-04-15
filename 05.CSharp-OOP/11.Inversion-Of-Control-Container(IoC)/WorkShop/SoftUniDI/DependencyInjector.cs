using SoftUniDI.Injectors;
using SoftUniDI.Modules.Contracts;

namespace SoftUniDI
{
    public static class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}