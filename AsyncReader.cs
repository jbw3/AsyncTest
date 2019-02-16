using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsyncTest
{
    public class AsyncCsvReader : ICsvReader
    {
        private StreamReader _Reader;

        private string[] _ColumnNames;

        private Task<string[]> _NextRowTask;

        public AsyncCsvReader(string filename)
        {
            _Reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));

            string columnLine = _Reader.ReadLine();
            _ColumnNames = columnLine.Split(',');

            _NextRowTask = GetNextRowAsync();
        }

        public IEnumerable<string> ColumnNames => _ColumnNames;

        public IEnumerable<string[]> Rows
        {
            get
            {
                _NextRowTask.Wait();
                string[] nextRow = _NextRowTask.Result;
                while (nextRow != null)
                {
                    _NextRowTask = GetNextRowAsync();

                    yield return nextRow;

                    _NextRowTask.Wait();
                    nextRow = _NextRowTask.Result;
                }
            }
        }

        public void Dispose() => _Reader.Dispose();

        private async Task<string[]> GetNextRowAsync()
        {
            Task<string> task = _Reader.ReadLineAsync();
            string line = await task;

            if (line == null)
            {
                return null;
            }

            return line.Split(',');
        }
    }
}
