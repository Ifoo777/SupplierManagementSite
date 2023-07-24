using Components.SupplierManagementApi.Requests;

namespace SupplierManagementSite.Core.Handlers.Suppliers
{
    public interface IGetSupplierHandler
    {
        Task<GetSupplierResponse> Handle(GetSupplierRequest request, CancellationToken cancellationToken);
    }
}