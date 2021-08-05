using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Update owner request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UpdateOwnerRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool State { get; set; }
    }
}
