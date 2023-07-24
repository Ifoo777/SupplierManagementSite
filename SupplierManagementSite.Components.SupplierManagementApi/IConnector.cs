using Components.SupplierManagementApi.Models;

namespace Components.SupplierManagementApi
{
    public interface IConnector
    {
        Task<ResponseWrapper<TResponse>> SendGetRequest<TResponse>(string url, CancellationToken cancellationToken);
        Task<ResponseWrapper<TResponse>> SendPostRequest<TResponse, TRequest>(string url, TRequest body, CancellationToken cancellationToken);
    }
}