using System;
using OpenQA.Selenium;

namespace WebCov.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public abstract class SelectorAttribute : Attribute
    {
        public abstract By GetSelector();
    }
}