using System;

namespace Weelo.Core.BaseEndpoints.Owner
{
    /// <summary>
    /// Create owner resquest
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class CreateOwnerRequest: BaseRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Image { get; set; }
    }
}
