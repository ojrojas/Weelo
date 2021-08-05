using System;
namespace Weelo.Core.BaseEndpoints.PropertyTrace
{
    /// <summary>
    /// Update property trace
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UpdatePropertyTraceRequest: BaseRequest
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool State { get; set; }
    }
}
