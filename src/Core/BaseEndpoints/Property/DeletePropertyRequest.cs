using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Delete property request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeletePropertyRequest : BaseRequest
    {
        public Guid PropertyId { get; set; }
    }
}
