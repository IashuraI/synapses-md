namespace Md.Domain.Entities.Google.Places_API.Autocomplete
{
    public class PlacesAutocompleteResponse
    {
        public List<PlaceAutocompletePrediction> predictions { get; set; } = new List<PlaceAutocompletePrediction>();
    }
}
