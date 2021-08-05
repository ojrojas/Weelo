using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// Dto PropertyDto Properties not Fk Model
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public  class PropertyDto
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
        public Guid PropertyImageId { get; set; }
        public PropertyTraceDto PropertyTrace { get; set; }
        public Guid PropertyTraceId { get; set; }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool State { get; set; }

    }
}
