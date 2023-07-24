using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Components.SupplierManagementApi.Models;
using SupplierManagementSite.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi
{
    public class Connector : IConnector
    {
        private readonly ILogger<Connector> logger;
        private readonly SupplierManagementApiConnectorOptions options = new SupplierManagementApiConnectorOptions();

        public Connector(ILogger<Connector> logger, IConfiguration configuration)
        {
            this.logger = logger;
            configuration.Bind("SupplierManagementApiConnectorOptions", options);
        }


        public async Task<ResponseWrapper<TResponse>> SendGetRequest<TResponse>(string url, CancellationToken cancellationToken)
        {
            ResponseWrapper<TResponse> response = new();
            try
            {
                logger.LogInformation($"Sending request:{url}");
                using (HttpClient httpClient = new())
                {
                    httpClient.BaseAddress = options.BaseUrl;
                    httpClient.Timeout = new TimeSpan(0, 0, options.Timeout);

                    var result = await httpClient.GetAsync(url, cancellationToken);
                    response.IsSuccess = result.IsSuccessStatusCode;
                    if (!result.IsSuccessStatusCode)
                    {
                        logger.LogWarning($"Sending request:{url} was not successful and responsed with status code :{result.StatusCode}");
                        response.HttpStatusCode = result.StatusCode;
                        return response;
                    }

                    if (result.Content != null)
                    {

                        var jsonString = await result.Content.ReadAsStringAsync(cancellationToken);
                        logger.LogInformation($"Request sent to:{url} responded with {jsonString}");
                        response.Response = JsonConvert.DeserializeObject<TResponse>(jsonString);
                    }

                    logger.LogInformation($"Request sent to:{url} completed succcessfuly.");
                    response.ResponseMessage = "Operation completed successfuly";
                    response.HttpStatusCode = result.StatusCode;
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Sending request:{url} encountered error: {ex.ToString()}");
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.ResponseMessage = $"Sending request to:{url} failed.";
                return response;
            }
        }


        public async Task<ResponseWrapper<TResponse>> SendPostRequest<TResponse, TRequest>(string url, TRequest body, CancellationToken cancellationToken)
        {
            ResponseWrapper<TResponse> response = new();
            try
            {
                logger.LogInformation($"Sending request:{url}");
                using (HttpClient httpClient = new())
                {
                    httpClient.BaseAddress = options.BaseUrl;
                    httpClient.Timeout = new TimeSpan(0, 0, options.Timeout);

                    var result = await httpClient.PostAsJsonAsync(url, body, cancellationToken);
                    response.IsSuccess = result.IsSuccessStatusCode;
                    if (!result.IsSuccessStatusCode)
                    {
                        logger.LogWarning($"Sending request:{url} was not successful and responsed with status code :{result.StatusCode}");
                        response.HttpStatusCode = result.StatusCode;
                        return response;
                    }

                    if (result.Content != null)
                    {

                        var jsonString = await result.Content.ReadAsStringAsync(cancellationToken);
                        logger.LogInformation($"Request sent to:{url} responded with {jsonString}");
                        response.Response = JsonConvert.DeserializeObject<TResponse>(jsonString);
                    }

                    logger.LogInformation($"Request sent to:{url} completed succcessfuly.");
                    response.ResponseMessage = "Operation completed successfuly";
                    response.HttpStatusCode = result.StatusCode;
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Sending request:{url} encountered error: {ex.ToString()}");
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.ResponseMessage = $"Sending request to:{url} failed.";
                return response;
            }
        }

    }
}
