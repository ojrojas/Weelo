using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class UpdatePropertyRequest : BaseRequest
    {
        public Guid PropertyId   { get; set; }
        public PropertyDto PropertyDto { get; set; }
    }
}
