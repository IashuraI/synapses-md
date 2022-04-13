using System.Diagnostics.CodeAnalysis;

namespace Md.Domain.Entities.Google.Places_API.Autocomplete
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class PlaceAutocompleteStructuredFormat
    {
        public string main_text { get; set; } = string.Empty;
        public string secondary_text { get; set; } = string.Empty;
    }
}
