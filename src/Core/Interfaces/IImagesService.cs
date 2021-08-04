using System;
using System.IO;
using System.Threading.Tasks;
using Weelo.Core.Dtos;

namespace Weelo.Core.Interfaces
{
    public interface IImagesService
    {
        Task<Stream> OpenImage(string route);
        Task<ImageDto> SaveImage(Stream stream, Guid id);
    }
}