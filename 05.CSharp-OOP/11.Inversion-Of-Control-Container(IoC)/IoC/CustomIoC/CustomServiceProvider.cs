using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace CustomIoC
{
    public class CustomServiceProvider : ICustomServiceProvider
    {
        private Dictionary<Type, Type> serviceCollection;

        public CustomServiceProvider(IDictionary<Type, Type> serviceCollection)
        {
            this.serviceCollection = new Dictionary<Type, Type>(serviceCollection);
        }

        public T GetService<T>() //T - interface
        {
            return (T) GetService(typeof(T));
        }

        private object GetService(Type type) //type - interface
        {
            if (!serviceCollection.ContainsKey(type))
            {
                throw new ArgumentException("Service not exist");
            }

            ParameterInfo[] constructorParameters = serviceCollection[type]
                .GetConstructors((BindingFlags)60)
                .First()
                .GetParameters();

            List<object> readyParameters = new List<object>();

            foreach (ParameterInfo parameter in constructorParameters)
            {
                if (!serviceCollection.ContainsKey(parameter.ParameterType))
                {
                    throw new ArgumentException("Service not exist!");
                }

                var readyParameter = GetService(parameter.ParameterType);

                readyParameters.Add(readyParameter);
            }


            var returnObject = Activator.CreateInstance(serviceCollection[type], readyParameters.ToArray());
            return returnObject;
        }
    }
}