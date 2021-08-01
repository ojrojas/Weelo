using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Model PropertyTrace
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class PropertyTrace : BaseEntity, IAggregateRoot
    {
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }

        public void UpdateProperties(Guid propertyId, DateTime dateSale, string name, decimal value, decimal tax, Guid modifiedBy, bool state)
        {
            PropertyId = propertyId;
            DateSale = dateSale;
            Name = name;
            Value = value;
            Tax = tax;
            ModifiedBy = modifiedBy;
            State = state;
        }
    }
}
