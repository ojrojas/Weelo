using System;

namespace Weelo.Core.Dtos
{
    public class ErrorDto
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string StackTrace { get; set; }
        public int ErrorCode { get; set; }
        public string RequestIp { get; set; }
        public string Payload { get; set; }
    }
}
