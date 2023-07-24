using Components.SupplierManagementApi.Models;
using Components.SupplierManagementApi.Requests;
using SupplierManagementSite.Models;

namespace Components.SupplierManagementApi.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<ResponseWrapper<AddSupplierResponse>> Add(Supplier model, CancellationToken cancellationToken);
        Task<ResponseWrapper<GetSupplierResponse>> Get(Query query, CancellationToken cancellationToken);
    }
}