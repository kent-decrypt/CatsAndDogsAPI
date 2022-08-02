namespace CatsAndDogs.Api.Models
{
    /// <summary>
    /// Model class when invalid data are given
    /// </summary>
    public class ErrorResponseModel
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
