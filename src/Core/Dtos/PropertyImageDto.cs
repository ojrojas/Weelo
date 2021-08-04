using System;
using Weelo.Core.Entities;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// PropertyImageDto Properties
    /// </summary>
    /// <author>Oscar Julian Rojas/author>
    /// <date>29/07/2021</date>
    public  class PropertyImageDto : BaseEntity
    {
        public Guid PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
