using Microsoft.AspNetCore.Http;
using System;

namespace Weelo.Core.Dtos
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string RouteImage { get; set; }
        public IFormFile File { get; set; }
    }
}
