using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Autocomplete
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class PlaceAutocompletePrediction
    {
        public string place_id { get; set; } = null!;
        public string description { get; set; } = string.Empty;
        public PlaceAutocompleteStructuredFormat structured_formatting { get; set; } = null!;
        public List<string> types { get; set; } = new List<string>();
    }
}
