using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// PropertyTraceDto 
    /// </summary>
    /// <author>Oscar Julian ROjas</author>
    /// <date>29/07/2021</date>
    public class PropertyTraceDto 
    {
        public Guid PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool State { get; set; }

    }
}
