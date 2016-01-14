using System.Collections.Generic;

namespace Core.Controllers
{
    public class RoundManager<T>
    {
        private readonly List<T> _source;

        private readonly Queue<T> _queue;

        public RoundManager(List<T> source)
        {
            _source = source;
            _queue = new Queue<T>(_source);
        }

        public T GetNext()
        {
            var result = _queue.Dequeue();
            _queue.Enqueue(result);

            return result;
        }

        public IEnumerable<T> Source => _source;
    }
}