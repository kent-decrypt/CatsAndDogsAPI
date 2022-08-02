namespace CatsAndDogs.Tests.Models
{
    /// <summary>
    /// Represents the Pet class model from the Business layer
    /// </summary>
    internal class PetFake
    {
        internal string Id { get; set; }
        internal string Name { get; set; }
        internal string Temperament { get; set; }
        internal string Origin { get; set; }
        internal ImageFake Image { get; set; }
        internal string? CountryCode { get; set; }
        internal string? Description { get; set; }
        internal string? BredFor { get; set; }
        internal string? BreedGroup { get; set; }
    }
}
