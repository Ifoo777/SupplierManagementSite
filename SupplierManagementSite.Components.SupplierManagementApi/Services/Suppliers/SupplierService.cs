using Components.SupplierManagementApi.Models;
using Components.SupplierManagementApi.Requests;
using SupplierManagementSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly IConnector connector;

        public SupplierService(IConnector connector)
        {
            this.connector = connector;
        }

        public async Task<ResponseWrapper<GetSupplierResponse>> Get(Query query, CancellationToken cancellationToken) =>
           await connector.SendGetRequest<GetSupplierResponse>($"Supplier/{query.Skip}/{query.Take}?Filter={query.Filter}", cancellationToken);

        public async Task<ResponseWrapper<AddSupplierResponse>> Add(Supplier model, CancellationToken cancellationToken) =>
            await connector.SendPostRequest<AddSupplierResponse, Supplier>($"Supplier", model, cancellationToken);
    }
}
