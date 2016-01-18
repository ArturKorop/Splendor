using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Common
{
    public class Shuffler<T>
    {
        private readonly Random _rand = new Random();

        public IEnumerable<T> Shuffle(IEnumerable<T> source)
        {
            var sourceList = source.ToList();
            var temp =
                (from item in sourceList
                let randomValue = _rand.Next(sourceList.Count)
                select new Tuple<int, T>(randomValue, item));

            var ordered = temp.OrderBy(x => x.Item1);

            return ordered.Select(x=>x.Item2);
        }
    }
}