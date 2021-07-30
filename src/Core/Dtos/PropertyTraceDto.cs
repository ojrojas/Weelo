using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// PropertyTraceDto 
    /// </summary>
    /// <author>Oscar Julian ROjas</author>
    /// <date>29/07/2021</date>
    public class PropertyTraceDto : BaseEntity
    {
        public Guid PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}
