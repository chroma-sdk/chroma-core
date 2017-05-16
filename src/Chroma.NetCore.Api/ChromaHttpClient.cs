using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Exceptions;
using Chroma.NetCore.Api.Extensions;
using Chroma.NetCore.Api.Interfaces;
using Chroma.NetCore.Api.Messages;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api
{
    internal class ChromaHttpClient : IClient
    {

        private HttpClient httpClient;
        private Timer heartbeatTimer;

        private string sessionId;
        
        public IDevice CallingDevice { get; set; }

        public event Action<HttpStatusCode, string, string> ClientMessage = delegate { };

        public ClientConfiguration ClientConfiguration { get; private set; }


        public bool Init(ClientConfiguration clientConfiguration)
        {
            ClientConfiguration = clientConfiguration;
            ClientConfiguration.ExposedBaseAddress = ClientConfiguration.ExposedBaseAddress ??clientConfiguration.BaseAddress;
            ClientConfiguration.PropertyChanged +=
                (sender, args) =>
                {
                    if (httpClient == null)
                        return;

                    httpClient = null;
                    httpClient = CreateHttpClient();
                };

            httpClient = CreateHttpClient();

            return true;
        }

        #region session

        /// <summary>
        /// Initialize ChromaSDK and get SessionId.
        /// </summary>
        /// <param name="jsonMessage">Application information as JSON string</param>
        /// <returns>SessionId as string</returns>
        public async Task<string> Register(string jsonMessage)
        {
            var registerMessage = new RegisterMessage(jsonMessage);
            var response = await Request(registerMessage);
           
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response, new JsonSerializerSettings());
             
            if(!result.ContainsKey("sessionid"))
                throw new ChromaNetCoreApiException($"Error when register API client: {response}");

            sessionId = result["sessionid"];
            var newExposedBaseAddress = new Uri(result["uri"]);

#if DEBUG

            if(Bootsrapper.DebugMode)
                newExposedBaseAddress = new Uri(result["uri"].Replace("localhost","localhost.fiddler"));
#endif

            ClientConfiguration.ExposedBaseAddress = newExposedBaseAddress;

            return sessionId;
        }

        /// <summary>
        /// Unregister ChromaSDK
        /// </summary>
        /// <returns>0|ErrorCode as string</returns>
        public async Task<string> UnRegister()
        {
            var unRegisterMessage = new UnRegisterMessage();
            var response = await Request(unRegisterMessage);

            var result =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(response, new JsonSerializerSettings());

            ClientConfiguration.ExposedBaseAddress = null;

            heartbeatTimer?.Dispose();

            return result["result"];
        }


        public async Task<int> Heartbeat()
        {
            //Set Timer
            heartbeatTimer = heartbeatTimer ?? new Timer(async state =>
            {
                await Heartbeat();
            }, null, 10000, 5000);

            var heartbeatMessage = new HeartbeatMessage();
            var response = await Request(heartbeatMessage);

            var result =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(response, new JsonSerializerSettings());

            return Convert.ToInt32(result["tick"]);

        }


        public async Task<string> Request(IHttpRequestMessage requestMessage)
        {
            HttpResponseMessage responseMessage;

            var messageContent = new StringContent(requestMessage.Message ?? string.Empty, Encoding.UTF8, "application/json");

            switch (requestMessage.HttpMessageMethod)
            {
                case Enums.HttpMessageMethod.Post:
                    responseMessage = await httpClient.PostAsync(requestMessage.UrlPath, messageContent);
                    break;

                case Enums.HttpMessageMethod.Delete:
                    responseMessage = await httpClient.DeleteAsync(requestMessage.UrlPath, messageContent);
                    break;
                    
                case Enums.HttpMessageMethod.Put:
                    responseMessage = await httpClient.PutAsync(requestMessage.UrlPath, messageContent);
                    break;
                default:
                    responseMessage = new HttpResponseMessage();
                    break;
            }

            CheckStatusCode(responseMessage);

            var responseString = await responseMessage.Content.ReadAsStringAsync();

            //fire event with response message
            ClientMessage(responseMessage.StatusCode, requestMessage.Device.Device ?? "n/a", responseString);

            return responseString;
        }

        #endregion

        #region HttpClient

        private HttpClient CreateHttpClient()
        {
            var client = httpClient ?? new HttpClient();
            CreateRequestHeader(client);
            return client;
        }

        private void CreateRequestHeader(HttpClient client)
        {
            client.BaseAddress = ClientConfiguration.ExposedBaseAddress;
           
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //set the request type to JSON
            client.Timeout = TimeSpan.FromSeconds(15);
        }


        private bool CheckStatusCode(HttpResponseMessage response)
        {

            if (response == null)
                throw new ChromaNetCoreApiException("An unexpected error occured on request!");

            var responseContent = response.Content.ReadAsStringAsync().Result;

            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:

                        if (ex.InnerException != null)
                        {
                            throw new ChromaNetCoreApiException(
                                "Operation error! ", ex.InnerException, response.StatusCode);
                        }

                        throw new ChromaNetCoreApiException(
                            "Operation error. Operation was not successful!", ex, response.StatusCode);

                    default:
                        throw new ChromaNetCoreApiException("Unexpected error!", ex,
                            response.StatusCode);
                }
            }
        }

        #endregion   
    }
}
