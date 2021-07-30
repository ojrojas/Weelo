using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// Dto Owner Properties
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class OwnerDto : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
