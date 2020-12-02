using System;
using System.Collections.Generic;
using System.IO;

namespace DataProvider
{
    public class DataProvider<T> : IDataProvider<T>
    {
        private readonly string _filenameTemplate;

        public DataProvider(string filenameTemplate)
        {
            _filenameTemplate = filenameTemplate;
        }

        public IEnumerable<T> Read(int day)
        {
            using var reader = GetStreamReader(string.Format(_filenameTemplate, day));
            var data = new List<T>();

            while (!reader.EndOfStream)
            {
                var value = reader.ReadLine();
                data.Add(ChangeType(value));
            }

            return data;
        }

        protected T ChangeType(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        private StreamReader GetStreamReader(string filename)
        {
            var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            return new StreamReader(stream);
        }
    }
}