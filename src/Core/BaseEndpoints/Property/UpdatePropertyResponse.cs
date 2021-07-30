﻿using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class UpdatePropertyResponse: BaseResponse
    {
        public UpdatePropertyResponse(Guid correlationId) : base(correlationId) { }
        public UpdatePropertyResponse() { }
        public PropertyDto PropertyDto { get; set; } = new PropertyDto();
    }
}
