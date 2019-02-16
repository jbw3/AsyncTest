using System.Collections.Generic;
using System.IO;

namespace AsyncTest
{
    public class SyncCsvReader : ICsvReader
    {
        private StreamReader _Reader;

        private string[] _ColumnNames;

        public SyncCsvReader(string filename)
        {
            _Reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));

            string columnLine = _Reader.ReadLine();
            _ColumnNames = columnLine.Split(',');
        }

        public IEnumerable<string> ColumnNames => _ColumnNames;

        public IEnumerable<string[]> Rows
        {
            get
            {
                string line = _Reader.ReadLine();
                while (line != null)
                {
                    string[] split = line.Split(',');
                    yield return split;

                    line = _Reader.ReadLine();
                }
            }
        }

        public void Dispose() => _Reader.Dispose();
    }
}
