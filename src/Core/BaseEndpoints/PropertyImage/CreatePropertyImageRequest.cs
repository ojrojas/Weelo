using System;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    public class CreatePropertyImageRequest: BaseRequest
    {
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
