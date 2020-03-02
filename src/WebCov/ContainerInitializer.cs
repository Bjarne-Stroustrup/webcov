using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebCov.Attributes;

namespace WebCov
{
    public class ContainerInitializer
    {
        private static readonly Type ContainerBaseType = typeof(Container);

        internal T Create<T>(ISearchContext searchContext, ICollection<By> selectors)
        {
            return (T)CreateContainer(typeof(T), searchContext, selectors);
        }

        public T Create<T>(IWebDriver webDriver) where T: Container
        {
            return (T)CreateContainer(typeof(T), webDriver, new By[]{});
        }

        public T Create<T>(IWebDriver webDriver, T root) where T: Container
        {
            InitContainerProps(root, webDriver, new By[]{});
            return root;
        }

        private static void InitContainerProps<TContainer>(TContainer container, ISearchContext searchContext, ICollection<By> parentContainerSelectors)
            where TContainer : Container
        {
            var containerProps = container
                .GetType()
                .GetProperties(
                    BindingFlags.Public | BindingFlags.NonPublic
                                        | BindingFlags.Static | BindingFlags.Instance
                                        | BindingFlags.FlattenHierarchy
                                        | BindingFlags.SetProperty)
                .Where(p => ContainerBaseType.IsAssignableFrom(p.PropertyType));

            foreach (var prop in containerProps)
            {
                var selectors = prop.GetCustomAttributes<SelectorAttribute>()
                        .Concat(prop.PropertyType.GetCustomAttributes<SelectorAttribute>())
                        .Select(pa => pa.GetSelector())
                        .ToArray();

                if (selectors.Length <= 0)
                {
                    continue;
                }

                var propSelectors = new List<By>(parentContainerSelectors) {new ByAll(selectors)};
                var propObject = CreateContainer(prop.PropertyType, searchContext, propSelectors);
                prop.SetValue(container, propObject);
            }
        }

        private static object CreateContainer(Type t, ISearchContext searchContext,  ICollection<By> selectors)
        {
            var container = (Container)Activator.CreateInstance(t);
            container.WebElementSearcher = new WebElementSearcher(searchContext, selectors);
            InitContainerProps(container, searchContext, selectors);
            return container;
        }
    }
}