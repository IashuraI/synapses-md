namespace Md.Domain.Entities.Google.Places_API.Details
{
    public class Geometry
    {
        public LatLngLiteral location { get; set; } = null!;

        public Bounds viewport { get; set; } = null!;
    }
}
