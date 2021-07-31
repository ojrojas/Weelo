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

        public void UpdateProperties(string name, string address, decimal price, int codeInternal, int year, Guid ownerId, Guid modifiedBy, bool state)
        {
            Name = name;
            Address = address;
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            OwnerId = ownerId;
            ModifiedBy = modifiedBy;
            State = state;
        }
    }
}
