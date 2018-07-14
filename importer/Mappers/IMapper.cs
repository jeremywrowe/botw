using System.Collections.Generic;
using models;

namespace importer.Mappers
{
    public interface IMapper
    {
        List<Model> MapMany(List<List<string>> data);
        Model Map(List<string> data);
    }
}