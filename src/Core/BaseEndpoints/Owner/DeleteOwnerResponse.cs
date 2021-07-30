using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Response Owner
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class DeleteOwnerResponse : BaseResponse
    {
        /// <summary>
        /// Owner Delete Response CQRS
        /// </summary>
        /// <param name="correlationId">CorrelatioId of request</param>
        public DeleteOwnerResponse(Guid correlationId) : base(correlationId) { }
        public DeleteOwnerResponse() { }

        public OwnerDto Owner { get; set; } = new OwnerDto();
    }
}
