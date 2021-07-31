using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Property Image Model Entity
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class PropertyImage : BaseEntity, IAggregateRoot
    {
        public Property Property { get; set; }
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }

        public void UpdateProperties(Guid propertyId, string file, bool enabled, Guid modifiedBy, bool state)
        {
            PropertyId = propertyId;
            File = file;
            Enabled = enabled;
            ModifiedBy = modifiedBy;
            State = state;
        }
    }
}
