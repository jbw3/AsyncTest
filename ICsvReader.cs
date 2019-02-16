using System;
using System.Collections.Generic;

namespace AsyncTest
{
    public interface ICsvReader : IDisposable
    {
        IEnumerable<string> ColumnNames { get; }

        IEnumerable<string[]> Rows { get; }
    }
}
