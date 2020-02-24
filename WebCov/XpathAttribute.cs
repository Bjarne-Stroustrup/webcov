using System;
using OpenQA.Selenium;

namespace WebCov
{
    public class XpathAttribute : Attribute
    {
        private readonly string _path;

        public XpathAttribute(string path)
        {
            _path = path;
        }

        public By GetSelector()
        {
            return By.XPath(_path);
        }
    }
}