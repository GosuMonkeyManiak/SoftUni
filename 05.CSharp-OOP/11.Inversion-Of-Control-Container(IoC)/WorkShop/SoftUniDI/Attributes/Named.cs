﻿using System;

namespace SoftUniDI.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class Named : Attribute
    {
        public Named(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}