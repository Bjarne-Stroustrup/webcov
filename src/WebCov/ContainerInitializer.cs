using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using WebCov.Attributes;

namespace WebCov
{
    public class ContainerInitializer
    {
        private static readonly Type ContainerBaseType = typeof(Container);
        private static readonly Type SelectorAttributeBaseType = typeof(SelectorAttribute);

        public T Initialize<T>(IWebDriver webDriver) where T: Container
        {
            return (T)CreateContainer(typeof(T), webDriver, new By[]{});
        }

        public T Initialize<T>(IWebDriver webDriver, T root) where T: Container
        {
            InitContainerProps(root, webDriver, new By[]{});
            return root;
        }

        private void InitContainerProps<TContainer>(TContainer container, ISearchContext searchContext, ICollection<By> parentContainerSelectors)
            where TContainer : Container
        {
            var containerProps = container
                .GetType()
                .GetProperties(
                    BindingFlags.Public | BindingFlags.NonPublic
                                        | BindingFlags.Static | BindingFlags.Instance
                                        | BindingFlags.FlattenHierarchy)
                .Where(p => ContainerBaseType.IsAssignableFrom(p.PropertyType));

            foreach (var prop in containerProps)
            {
                var propAttribute = prop.GetCustomAttribute<SelectorAttribute>()
                                    ?? prop.PropertyType.GetCustomAttribute<SelectorAttribute>();

                if (propAttribute == null)
                {
                    continue;
                }

                var propSelector = propAttribute.GetSelector();
                var propSelectors = new List<By>(parentContainerSelectors) {propSelector};
                var propObject = CreateContainer(prop.PropertyType, searchContext, propSelectors, container);
                prop.SetValue(container, propObject);
            }
        }

        private object CreateContainer(Type t, ISearchContext searchContext,  ICollection<By> selectors, Container parent = null)
        {
            var container = (Container)Activator.CreateInstance(t);
            container.WebElementSearcher = new WebElementSearcher(searchContext, selectors);
            container.ParentContainer = parent;
            InitContainerProps(container, searchContext, selectors);
            return container;
        }
    }
}