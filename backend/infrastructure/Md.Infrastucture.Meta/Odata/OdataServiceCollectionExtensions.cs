using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace Md.Infrastucture.Meta.Odata
{
    public static class OdataServiceCollectionExtensions
    {
        public static IServiceCollection AddFormaters(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcCore(options =>
            {
                foreach (ODataOutputFormatter outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(odof => odof.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (ODataInputFormatter inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(odif => odif.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            return serviceCollection;
        }
    }
}
