using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Autocomplete
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class PlacesAutocompleteResponse
    {
        public List<PlaceAutocompletePrediction> predictions { get; set; } = new List<PlaceAutocompletePrediction>();
    }
}
