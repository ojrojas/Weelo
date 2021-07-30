using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class CreateOwnerRequest: BaseRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
