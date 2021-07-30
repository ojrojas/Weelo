using System;

namespace Weelo.Core.BaseEndpoints
{
    /// <summary>
    /// Base response to request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class BaseResponse : BaseMessage
    {
        /// <summary>
        /// Constructor BaseReposnse correlation request
        /// </summary>
        /// <param name="correlationId">Correlation request</param>
        public BaseResponse(Guid correlationId) : base()
        {
            base._correlationId = correlationId;
        }

        /// <summary>
        /// Constructor Blank improve instances
        /// </summary>
        public BaseResponse()
        {

        }
    }
}
