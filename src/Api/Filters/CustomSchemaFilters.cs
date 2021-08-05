using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Weelo.Api.Filters
{
    /// <summary>
    /// Filters schema correlation 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class CustomSchemaFilters : ISchemaFilter
    {
        /// <summary>
        /// Apply custom filter
        /// </summary>
        /// <param name="schema">Schema context</param>
        /// <param name="context">Context schema swagger</param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var excludeProperties = new[] { "CorrelationId" };

            foreach (var prop in excludeProperties)
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
        }
    }
}
