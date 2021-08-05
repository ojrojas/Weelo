using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// PropertyImageDto Properties
    /// </summary>
    /// <author>Oscar Julian Rojas/author>
    /// <date>29/07/2021</date>
    public  class PropertyImageDto 
    {
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool State { get; set; }

    }
}
