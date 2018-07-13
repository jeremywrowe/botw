using System.Collections.Generic;
using models;

namespace importer.Mappers
{
    public interface IMapper
    {
        Model Map(List<string> data);
    }
}