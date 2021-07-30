using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    /// <summary>
    /// Model Entity Owner
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class Owner : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }

        public void UpdateProperties(string name, string address, string photo, DateTime birthday, Guid modifiedBy, bool state)
        {
            Name = name;
            Address = address;
            Photo = photo;
            Birthday = birthday;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
            State = state;
        }
    }
}
