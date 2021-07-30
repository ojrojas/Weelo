using Ardalis.Specification;
using Weelo.Core.Entities;

namespace Weelo.Core.Specifications
{
    public class LoginSpecification : Specification<User>
    {
        public LoginSpecification(string userName, string password)
        {
            Query.Where(user => user.UserName == userName && user.Password == password);
        }
    }
}
