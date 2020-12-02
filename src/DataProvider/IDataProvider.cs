using System.Collections.Generic;

namespace DataProvider
{
    public interface IDataProvider<out T>
    {
        IEnumerable<T> Read(int day);
    }
}