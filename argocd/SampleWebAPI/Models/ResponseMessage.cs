using SampleWebAPI.Converters;
using SampleWebAPI.Enums;
using Newtonsoft.Json;

namespace SampleWebAPI.Models;

    public class ResponseMessage
    {
        [JsonConverter(typeof(SerializePropertyAsDefaultConverter<ResultCode>))]
        public ResultCode ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public dynamic Payload { get; set; }
    }