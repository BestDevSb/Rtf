using System.Collections.Generic;

namespace RtfGenerator.Generator
{
    internal interface IGenerator<T>
    {
        T GetNext(IList<T> source);
    }
}
