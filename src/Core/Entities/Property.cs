using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Model Entity Property
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class Property : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int Calification { get; set; }
        public int Rating { get; set; }
        public PropertyImage PropertyImage { get; set; }
        public Guid PropertyImageId { get; set; }
        public PropertyTrace PropertyTrace { get; set; }
        public Guid PropertyTraceId { get; set; }


        public void UpdateProperties(string name,
                                     string address,
                                     decimal price,
                                     int codeInternal,
                                     int year,
                                     Guid ownerId,
                                     int calification,
                                     int rating,
                                     Guid propertyImageId,
                                     Guid propertyTraceId,
                                     Guid modifiedBy,
                                     bool state)
        {
            Name = name;
            Address = address;
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            OwnerId = ownerId;
            Calification = calification;
            Rating = rating;
            PropertyImageId = propertyImageId;
            PropertyTraceId = propertyTraceId;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
            State = state;
        }
    }
}
