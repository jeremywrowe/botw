namespace models
{
    public abstract class Model
    {
        public abstract override string ToString();
        public abstract override bool Equals(object other);
    }
}