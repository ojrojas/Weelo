using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// User Dto entity
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UserDto: BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
