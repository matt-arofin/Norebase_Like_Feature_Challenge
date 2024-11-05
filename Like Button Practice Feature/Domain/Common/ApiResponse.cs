using Norebase_Like_Feature_Challenge.Domain.Entities;
using System.Text.Json.Serialization;

namespace Norebase_Like_Feature_Challenge.Domain.Common
{
    public class ApiResponse<TData>
    {
        [JsonPropertyName("Status")]
        public string? StatusCode { get; set; }
        [JsonPropertyName("IsSuccessful")]
        public bool IsSuccessful { get; set; }
        [JsonPropertyName("Message")]
        public string? Message { get; set; }
        [JsonPropertyName("Data")]
        public TData? Data { get; set; }

        public ApiResponse()
        {

        }
    
        public ApiResponse(TData data, string statusCode, string message)
        {
            StatusCode = statusCode;
            IsSuccessful = statusCode == "00";
            Message = message;
            Data = data;
        }

        public ApiResponse(string statusCode, string message)
        {
            StatusCode = statusCode;
            IsSuccessful = statusCode == "00";
            Message = message;
        }
    }

}
