using System;

namespace Weelo.Core.BaseEndpoints.User
{
    public class CreateUserRequest : BaseRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
