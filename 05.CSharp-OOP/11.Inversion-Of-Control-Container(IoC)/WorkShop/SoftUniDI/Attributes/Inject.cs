using System;

namespace SoftUniDI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
        
    }
}