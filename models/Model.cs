using System;

namespace models
{
    public class Model
    {
        public string Name { get; set; }
        public int Id => Name.GetHashCode();

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }
    }
}