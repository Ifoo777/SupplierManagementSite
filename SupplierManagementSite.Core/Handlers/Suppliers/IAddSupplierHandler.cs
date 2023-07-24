using Components.SupplierManagementApi.Requests;
using SupplierManagementSite.Models;

namespace SupplierManagementSite.Core.Handlers.Suppliers
{
    public interface IAddSupplierHandler
    {
        Task<AddSupplierResponse> Handle(Supplier model, CancellationToken cancellationToken);
    }
}