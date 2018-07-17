using System;
using System.Security.Cryptography;
using System.Text;

namespace models
{
    public class Model
    {
        public string Name { get; set; }
        public Guid Id
        {
            get
            {
                var md5Hasher = MD5.Create();
                var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(Name));
                return new Guid(data);
            }
        }

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