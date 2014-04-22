using Newtonsoft.Json;
using System.Net;

namespace MintPalAPI
{
    internal class JsonResponse<T>
    {
        private T _data;

        [JsonProperty("status")]
        private string Status { get; set; }
        [JsonProperty("message")]
        private string Message { get; set; }

        [JsonProperty("data")]
        internal T Data {
            get { return _data; }

            private set {
                if (Status != "success") {
                    if (string.IsNullOrWhiteSpace(Message))  throw new WebException("Could not parse data from the server.", WebExceptionStatus.UnknownError);
                    throw new WebException("Could not parse data from the server: " + Message, WebExceptionStatus.UnknownError);
                }

                _data = value;
            }
        }
    }
}
