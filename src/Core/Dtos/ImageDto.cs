using Microsoft.AspNetCore.Http;
using System;

namespace Weelo.Core.Dtos
{
    /// <summary>
    /// ImageDto 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string RouteImage { get; set; }
        public IFormFile File { get; set; }
    }
}
