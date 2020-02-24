using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;

namespace WebCov
{
    public class ContainerInitializer
    {
        private readonly Type _containerBaseType = typeof(Container);
        private readonly Type _selectorAttributeBaseType = typeof(XpathAttribute);

        public T Create<T>(IWebDriver webDriver) where T: Container
        {
            return (T)CreateContainer(typeof(T), webDriver, new By[]{});
        }

        private void InitContainerProps<TContainer>(TContainer container, ISearchContext context, ICollection<By> parentContainerSelectors) where TContainer : Container
        {
            var containerProps = container.GetType()
                .GetProperties(BindingFlags.Default)
                .Where(p =>
                    _containerBaseType.IsAssignableFrom(p.PropertyType)
                    && _containerBaseType.GetCustomAttributesData()
                        .Any(pd => _selectorAttributeBaseType.IsAssignableFrom(pd.AttributeType)))
                .ToArray();

            foreach (var prop in containerProps)
            {
                var propSelector = prop.GetCustomAttribute<XpathAttribute>().GetSelector();
                var propSelectors = new List<By>(parentContainerSelectors) {propSelector};
                var propObject = CreateContainer(prop.PropertyType, context, propSelectors, container);
                prop.SetValue(container, propObject);
            }
        }

        private object CreateContainer(Type t, ISearchContext context,  ICollection<By> selectors, Container parent = null)
        {
            var container = (Container)Activator.CreateInstance(t);
            container.WebElementSearcher = new WebElementSearcher(context, selectors);
            container.ParentContainer = parent;
            InitContainerProps(container, context, selectors);
            return container;
        }
    }
}