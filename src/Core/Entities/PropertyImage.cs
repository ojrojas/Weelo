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
        public int Width { get; set; }
        public int Height { get; set; }

        public void UpdateProperties(Guid propertyId, string file, bool enabled, int width, int height, Guid modifiedBy,
                                    Guid createdBy, DateTime createdOn, bool state)
        {
            PropertyId = propertyId;
            File = file;
            Enabled = enabled;
            Width = width;
            Height = height;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            State = state;
        }
    }
}
