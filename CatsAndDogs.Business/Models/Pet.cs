namespace CatsAndDogs.Business.Models
{
    /// <summary>
    /// Model class for both the dog and cat
    /// </summary>
    public class Pet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Temperament { get; set; }
        public string Origin { get; set; }
        public Image Image { get; set; }
        public string? CountryCode { get; set; }
        public string? Description { get; set; }
        public string? BredFor { get; set; }
        public string? BreedGroup { get; set; }

    }
}
