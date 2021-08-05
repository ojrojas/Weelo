using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Weelo.Core.Dtos;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Services
{
    /// <summary>
    /// Image services
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ImagesService : IImagesService
    {
        private readonly ILogger<ImagesService> _logger;
        private const int Width = 100;
        private const int Height = 100;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="logger">Logger application</param>
        public ImagesService(ILogger<ImagesService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Save image 
        /// </summary>
        /// <param name="stringBase64">Image base64</param>
        /// <param name="id">id owner or property</param>
        /// <returns>Image dto</returns>
        public async Task<ImageDto> SaveImage(string stringBase64, Guid id)
        {
            var bytes = Convert.FromBase64String(stringBase64);
            Stream stream = new MemoryStream(bytes);
            using var image = new Bitmap(stream);
            var directoryImages = Directory.GetCurrentDirectory() + "Images";

            if (!Directory.Exists(directoryImages))
                Directory.CreateDirectory(directoryImages);

            var resized = new Bitmap(Width, Height);
            using var graphics = Graphics.FromImage(resized);

            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(image, 0, 0, Width, Height);
            var route = directoryImages + $"image-{id}";
            resized.Save(route, ImageFormat.Png);
            _logger.LogInformation($"Saving image-{id} thumbnail");

            await Task.CompletedTask;

            return new ImageDto
            {
                Id = id,
                RouteImage = route
            };
        }

        /// <summary>
        /// Open Image stream
        /// </summary>
        /// <param name="route">route images</param>
        /// <returns>Stream image</returns>
        public async Task<Stream> OpenImage(string route)
        {
            using FileStream pngStream = new FileStream(route, FileMode.Open, FileAccess.Read);
            await Task.CompletedTask;
            return pngStream;
        }
    }
}
