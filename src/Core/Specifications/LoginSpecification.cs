using Ardalis.Specification;
using Weelo.Core.Entities;

namespace Weelo.Core.Specifications
{
    /// <summary>
    /// Specification LoginService 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class LoginSpecification : Specification<User>
    {
        /// <summary>
        /// Login Specification username password
        /// </summary>
        /// <param name="userName">string username</param>
        /// <param name="password">string password</param>
        public LoginSpecification(string userName, string password)
        {
            Query.Where(user => user.UserName == userName && user.Password == password);
        }
    }
}
