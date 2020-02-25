using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebCov
{
    public static class ContainerExtensions
    {
        public static IReadOnlyCollection<Container> GetContainers<TContainer>(this TContainer container)
            where TContainer : Container
        {
            return GetContainers<Container, TContainer>(container);
        }

        public static IReadOnlyCollection<T> GetContainers<T, TContainer>(this TContainer container)
            where T : Container
            where TContainer : Container
        {
            var searcher = container.WebElementSearcher;

            // Todo [2020/02/25 KL] Not efficient, need another way to get element count
            var containersCount = searcher.FindAllElements().Count;

            if (containersCount <= 0)
            {
                return new T[0];
            }

            var initializer = new ContainerInitializer();

            var baseSelector = searcher.Selector;
            var searchContext = searcher.Context;

            var subContainers = new List<T>();
            for (var i = 1; i <= containersCount; i++)
            {
                // BUG Doesn't work starting from i == 2
                var containerSelector = baseSelector.Nth(i);
                var subContainer = initializer.Create<T>(searchContext, new[] {containerSelector});
                subContainers.Add(subContainer);
            }

            return subContainers;
        }
    }
}