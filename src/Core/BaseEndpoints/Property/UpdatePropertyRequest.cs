using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Property
{
    /// <summary>
    /// Update property request
    /// </summary>
    /// <author>Oscar Julian ROjas</author>
    public class UpdatePropertyRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public int Calification { get; set; }
        public int Rating { get; set; }
        public PropertyImageDto PropertyImage { get; set; }
        public Guid PropertyImageId { get; set; }
        public PropertyTraceDto PropertyTrace { get; set; }
        public Guid PropertyTraceId { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool State { get; set; }
    }
}
