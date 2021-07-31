using System;

namespace Weelo.Core.BaseEndpoints.Property
{
    public class CreatePropertyRequest: BaseRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CreatedBy{ get; set; }
    }
}
