using System;

namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    public class CreatePropertyTraceRequest: BaseRequest
    {
        public Guid PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
