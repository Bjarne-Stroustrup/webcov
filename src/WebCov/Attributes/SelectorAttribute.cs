using System;
using OpenQA.Selenium;

namespace WebCov.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public abstract class SelectorAttribute : Attribute
    {
        public abstract By GetSelector();
    }
}