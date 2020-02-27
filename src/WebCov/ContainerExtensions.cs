using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebCov
{
    public static class ContainerExtensions
    {
        private static readonly ContainerInitializer Initializer = new ContainerInitializer();

        public static IReadOnlyCollection<T> AsContainerCollection<T>(this T container)
            where T : Container
        {
            return AsContainerCollection<T, T>(container);
        }

        public static IReadOnlyCollection<T> AsContainerCollection<T, TContainer>(this TContainer container)
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

            var subContainers = new List<T>();
            for (var i = 0; i < containersCount; i++)
            {
                subContainers.Add(container.Nth<T, TContainer>(i));
            }

            return subContainers;
        }

        public static T Nth<T>(this T container, int index)
            where T : Container
        {
            return Nth<T, T>(container, index);
        }

        public static T Nth<T, TContainer>(this TContainer container, int index)
            where T : Container
            where TContainer : Container
        {
            var containerSelector = container.WebElementSearcher.Selector.Nth(index);
            var nthContainer = Initializer.Create<T>(container.WebElementSearcher.Context, new[] {containerSelector});
            return nthContainer;
        }
    }


}