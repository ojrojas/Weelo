using System;
using System.IO;
using System.Threading.Tasks;
using Weelo.Core.Dtos;

namespace Weelo.Core.Interfaces
{
    /// <summary>
    /// Image services interface
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public interface IImagesService
    {
        /// <summary>
        /// Open image save disk 
        /// </summary>
        /// <param name="route">Route image</param>
        /// <returns>Stream image</returns>
        Task<Stream> OpenImage(string route);

        /// <summary>
        /// Save Image 
        /// </summary>
        /// <param name="stringBase64">Image base64</param>
        /// <param name="id">id property owner o property</param>
        /// <returns>Image Dto</returns>
        Task<ImageDto> SaveImage(string stringBase64, Guid id);
    }
}