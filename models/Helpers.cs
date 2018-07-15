using System.Linq;

namespace models
{
    public class Helpers
    {
        public static string ArrayToString(string[] data)
        {
            var quoted = from item in data select $"'{item}'";
            return $"[{string.Join(", ", quoted.ToList())}]";
        }
    }
}