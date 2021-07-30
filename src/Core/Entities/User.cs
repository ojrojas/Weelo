using System;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void UpdateProperties(string name, string lastName, string userName, string password, Guid modifiedBy, bool state)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
            State = state;
        }
    }
}
