using System;
using Weelo.Core.Dtos;

namespace Weelo.Core.BaseEndpoints.PropertyImage
{
    /// <summary>
    /// Update property image request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class UpdatePropertyImageRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime  ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool State { get; set; }
    }
}
