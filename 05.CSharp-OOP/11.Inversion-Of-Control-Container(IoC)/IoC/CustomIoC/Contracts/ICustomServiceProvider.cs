using System;

namespace CustomIoC
{
    public interface ICustomServiceProvider
    {
        T GetService<T>();
    }
}