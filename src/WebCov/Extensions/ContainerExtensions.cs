using System;
using System.Collections.Generic;

namespace WebCov.Extensions
{
    public static class ContainerExtensions
    {
        public static bool WaitUntilExist(this Container container, TimeSpan timeout)
        {
            var endTime = DateTime.Now.Add(timeout);
            while (true)
            {
                if (DateTime.Now > endTime)
                {
                    return false;
                }

                var webElement = container.WebElement;
                if (webElement != null)
                {
                    return true;
                }
            }
        }

        public static IReadOnlyCollection<T> AsCollection<T>(this T container)
            where T : Container
        {
            return AsCollection<T, T>(container);
        }

        public static IReadOnlyCollection<T> AsCollection<T, TContainer>(this TContainer container)
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
            var containerSelector = container.WebElementSearcher.Selector.IndexCurrentLevel(index);
            var nthContainer = Container.Create<T>(container.WebElementSearcher.Context, new[] {containerSelector});
            return nthContainer;
        }
    }
}