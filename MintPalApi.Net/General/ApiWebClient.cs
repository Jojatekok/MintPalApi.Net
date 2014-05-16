using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI
{
    sealed class ApiWebClient
    {
        internal string BaseUrl { get; private set; }

        internal Authenticator Authenticator { private get; set; }

        private static readonly JsonSerializer JsonSerializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
        private static readonly Encoding Encoding = Encoding.UTF8;

        internal ApiWebClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        internal async Task<T> GetDataAsync<T>(object baseObject, bool authenticate, string command, params object[] parameters)
        {
            var relativeUrl = CreateRelativeUrl(authenticate, command, parameters);

            var jsonString = await QueryStringAsync("GET", relativeUrl);
            var output = JsonSerializer.DeserializeObject<JsonResponse<T>>(jsonString).Data;

            SetBaseObjects(output, baseObject);
            return output;
        }

        internal async Task DeleteDataAsync(string command, params object[] parameters)
        {
            var relativeUrl = CreateRelativeUrl(true, command, parameters);

            var jsonString = await QueryStringAsync("DELETE", relativeUrl);
            JsonSerializer.DeserializeObject<JsonResponse<object>>(jsonString).CheckStatus();
        }

        internal async Task<T> PostDataAsync<T>(object baseObject, string command, Dictionary<string, object> postData)
        {
            var relativeUrl = Authenticator.GetUrl(BaseUrl + command);

            var jsonString = await PostStringAsync(relativeUrl, postData.ToHttpPostString());
            var output = JsonSerializer.DeserializeObject<JsonResponse<T>>(jsonString).Data;

            SetBaseObjects(output, baseObject);
            return output;
        }

        private async Task<string> QueryStringAsync(string method, string relativeUrl)
        {
            var request = CreateHttpWebRequest(method, relativeUrl);

            return await request.GetResponseStringAsync();
        }

        private async Task<string> PostStringAsync(string relativeUrl, string postData)
        {
            var request = CreateHttpWebRequest("POST", relativeUrl);
            request.ContentType = "application/json";

            var postBytes = Encoding.GetBytes(postData);
            request.ContentLength = postBytes.Length;

            using (var requestStream = await request.GetRequestStreamAsync()) {
                await requestStream.WriteAsync(postBytes, 0, postBytes.Length);
            }

            return await request.GetResponseStringAsync();
        }

        private string CreateRelativeUrl(bool authenticate, string command, object[] parameters)
        {
            var relativeUrl = command;
            if (parameters.Length != 0) {
                relativeUrl += "/" + string.Join("/", parameters);
            }

            if (authenticate) relativeUrl = Authenticator.GetUrl(BaseUrl + relativeUrl);

            return relativeUrl;
        }

        private HttpWebRequest CreateHttpWebRequest(string method, string relativeUrl)
        {
            var request = WebRequest.CreateHttp(BaseUrl + relativeUrl);
            request.Method = method;
            request.UserAgent = "MintPal API .NET v" + Helper.AssemblyVersionString;

            request.Timeout = Helper.RequestsTimeoutMilliseconds;

            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            return request;
        }

        private static void SetBaseObjects(object input, object baseObject)
        {
            var refreshableObject = input as RefreshableObject;
            if (refreshableObject != null) {
                refreshableObject.BaseObject = baseObject;
                return;
            }

            var refreshableObjects = input as IList;
            if (refreshableObjects != null) {
                for (var i = refreshableObjects.Count - 1; i >= 0; i--) {
                    refreshableObject = refreshableObjects[i] as RefreshableObject;
                    if (refreshableObject != null) {
                        refreshableObject.BaseObject = baseObject;
                    }
                }
            }
        }
    }
}
