using System;
using System.Collections.Generic;

namespace CustomIoC
{
    public class CustomServiceCollection : ICustomServiceCollection
    {
        private Dictionary<Type, Type> serviceCollection;

        public CustomServiceCollection()
        {
            serviceCollection = new Dictionary<Type, Type>();
        }

        public void Map<TInterface, TImplementation>()
                    where TInterface : class
                    where TImplementation : class
        {
            if (!serviceCollection.ContainsKey(typeof(TInterface)))
            {
                serviceCollection.Add(typeof(TInterface), typeof(TImplementation));
            }
        }

        public ICustomServiceProvider BuildCustomServiceProvider()
        {
            return new CustomServiceProvider(serviceCollection);
        }
    }
}