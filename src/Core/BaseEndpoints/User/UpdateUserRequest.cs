using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.User
{
    public class UpdateUserRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool State { get; set; }
    }
}
