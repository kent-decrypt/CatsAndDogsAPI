namespace CatsAndDogs.Tests.Models
{
    /// <summary>
    /// Represents the ResultSet class Model from the Business Layer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ResultSetFake<T>
    {
        public int Page { get; internal set; }
        public int Limit { get; internal set; }
        public T Result { get; internal set; }
    }
}
