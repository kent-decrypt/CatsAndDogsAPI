namespace CatsAndDogs.Business.Models
{
    /// <summary>
    /// Model class for the API result
    /// </summary>
    public class ResultSet<T>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public T Result { get; set; } 
    }
}
