using System;
using System.Collections.Generic;
using System.Text;

namespace RtfGenerator.Generator
{
    internal class Generator<T> : IGenerator<T>
    {
        private readonly IRandomIndexGenerator _generator;

        public Generator(IRandomIndexGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public T GetNext(IList<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            int index = _generator.GetNext(0, source.Count);

            return source[index];
        }
    }
}
