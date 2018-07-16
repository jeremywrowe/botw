using System.Collections.Generic;
using models;

namespace importer.Mappers
{
    public interface IMapper<T>
    {
        List<T> MapMany(List<List<string>> data);
        T Map(List<string> data);
    }
}