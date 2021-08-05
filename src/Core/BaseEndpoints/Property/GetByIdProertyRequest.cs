using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// GetById request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class GetByIdProertyRequest: BaseRequest
    {
        public Guid PropertyId { get; set; }
    }
}
