using System;
using System.Collections.Generic;
using System.Text;

namespace RtfGenerator.Generator
{
    public interface IRandomIndexGenerator
    {
        int GetNext(int min, int max);
    }
}
