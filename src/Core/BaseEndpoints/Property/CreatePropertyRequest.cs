using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Create property request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class CreatePropertyRequest: BaseRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public int Calification { get; set; }
        public int Rating { get; set; }
        public PropertyImageDto PropertyImage { get; set; }
        public PropertyTraceDto PropertyTrace { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
