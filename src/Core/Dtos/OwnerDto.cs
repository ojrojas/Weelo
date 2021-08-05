using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// Dto Owner Properties
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class OwnerDto 
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool State { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
