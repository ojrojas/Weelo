using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.Owner
{
    public class UpdateOwnerRequest : BaseRequest
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool State { get; set; }
    }
}
