using System.IO;
using System.Threading.Tasks;

namespace Weelo.Api.Helpers
{
    /// <summary>
    /// Helper read body requests
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>30/07/2021</date>
    public class ReadRequestBody
    {
        public static async Task<string> ReadRquestBodyFunction(Stream body)
        {
            return await new StreamReader(body).ReadToEndAsync();
        }
    }
}
