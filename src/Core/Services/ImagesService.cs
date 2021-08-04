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
    public class ImagesService : IImagesService
    {
        private readonly ILogger<ImagesService> _logger;
        private const int Width = 100;
        private const int Height = 100;

        public ImagesService(ILogger<ImagesService> logger)
        {
            _logger = logger;
        }

        public async Task<ImageDto> SaveImage(Stream stream, Guid id)
        {
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

        public async Task<Stream> OpenImage(string route)
        {
            using FileStream pngStream = new FileStream(route, FileMode.Open, FileAccess.Read);
            await Task.CompletedTask;
            return pngStream;
        }
    }
}
