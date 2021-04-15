using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;

namespace SoftUniDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }


        public abstract void Configure();

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: " + currentInterface.FullName);
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;

                string dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TService, TImplementation>()
        {
            if (!this.implementations.ContainsKey(typeof(TService)))
            {
                this.implementations[typeof(TService)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TService)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }
    }
}