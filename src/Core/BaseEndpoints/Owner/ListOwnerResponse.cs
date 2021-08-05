using System;
using System.Collections.Generic;
using System.Text;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// List owners reponse
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ListOwnerResponse : BaseResponse
    {
        public ListOwnerResponse(Guid correlationId) : base(correlationId) { }
        public ListOwnerResponse() { }
        public List<OwnerDto> Owners { get; set; } = new List<OwnerDto>();
        public string Message { get; set; }
    }
}
