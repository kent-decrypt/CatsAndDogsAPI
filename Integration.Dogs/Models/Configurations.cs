namespace Integration.Dogs.Api.Models
{
    /// <summary>
    /// Configuration model class for the dogs
    /// </summary>
    public class Configurations
    {
        public DogsApi DogsApi { get; set; }
    }

    /// <summary>
    /// The Dogs Api Configurations
    /// </summary>
    public class DogsApi
    {
        public string Secret { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
    }
}
