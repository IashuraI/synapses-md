using Md.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Md.Domain.Entities.Location
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        [NotMapped]
        public string? GooglePlaceId { get; set; }
    }
}
