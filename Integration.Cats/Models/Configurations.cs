namespace Integration.Cats.Api.Models
{
    /// <summary>
    /// Configuration model class for the cats
    /// </summary>
    public class Configurations
    {
        public CatsApi CatsApi { get; set; }
    }

    /// <summary>
    /// The Cats Api Configurations
    /// </summary>
    public class CatsApi
    {
        public string Secret { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
    }
}
