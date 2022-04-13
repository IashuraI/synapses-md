using Md.Domain.Entities.Google.Places_API.Details;
using Md.Domain.Entities.Google.Places_API.Autocomplete;
using Md.Domain.Entities.Location;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Md.Application.Google
{
    public class GooglePlacesApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GooglePlacesApiService(HttpClient httpClient, IConfiguration _configuration)
        {
            _httpClient = httpClient;
            _apiKey = _configuration["GoogleApiKey"];
        }

        public async Task<List<Address>> AddressListBySearchTerm(string searchTerm)
        {
            string requestUrl = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={searchTerm.Replace(" ", "+")}&key={_apiKey}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUrl);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Stream contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                PlacesAutocompleteResponse? placesAutocompleteResponse = 
                    await JsonSerializer.DeserializeAsync<PlacesAutocompleteResponse>(contentStream);

                if(placesAutocompleteResponse != default)
                {
                    return ParseGoogleMapsAddressList(placesAutocompleteResponse.predictions);
                }
            }

            return new List<Address>();
        }

        public async Task<Address?> PopulateAddressDetailsByGooglePlaceId(string googlePlaceId)
        {
            string url = $"https://maps.googleapis.com/maps/api/place/details/json?place_id={googlePlaceId}&key={_apiKey}&fields=address_component,geometry,place_id";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Stream contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                PlacesDetailsResponse? placesDetailsResponse = await JsonSerializer.DeserializeAsync<PlacesDetailsResponse>(contentStream);

                if (placesDetailsResponse != default && placesDetailsResponse.result != default)
                {
                    return ParseGoogleMapsAddress(placesDetailsResponse.result);
                }
            }

            return default;
        }

        private List<Address> ParseGoogleMapsAddressList(List<PlaceAutocompletePrediction> placeAutocompletePredictions)
        {
            List<Address> list = new();

            foreach (PlaceAutocompletePrediction placeAutocompletePrediction in placeAutocompletePredictions)
            {
                list.Add(new Address
                {
                    GooglePlaceId = placeAutocompletePrediction.place_id,
                    AddressLine = placeAutocompletePrediction.description,
                });
            }

            return list;
        }

        private Address ParseGoogleMapsAddress(Place place)
        {
            Address address = new();

            foreach (AddressComponent addressComponent in place.address_components)
            {
                if (addressComponent.types.Contains("street_number") || addressComponent.types.Contains("route"))
                {
                    address.AddressLine = addressComponent.short_name;
                }
                if (addressComponent.types.Contains("locality")
                    || addressComponent.types.Contains("sublocality")
                    || addressComponent.types.Contains("sublocality_level_1"))
                {
                    address.City = addressComponent.short_name;
                }
                if (addressComponent.types.Contains("administrative_area_level_1"))
                {
                    address.State = addressComponent.short_name;
                }
                if (addressComponent.types.Contains("postal_code"))
                {
                    address.Zip = addressComponent.short_name;
                }
            }

            address.Lat = place.geometry.location.lat;
            address.Lng = place.geometry.location.lng;

            address.GooglePlaceId = place.place_id;

            return address;
        }

    }
}
