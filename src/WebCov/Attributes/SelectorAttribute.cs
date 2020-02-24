using System;
using OpenQA.Selenium;

namespace WebCov.Attributes
{
    public abstract class SelectorAttribute : Attribute
    {
        public abstract By GetSelector();
    }
}