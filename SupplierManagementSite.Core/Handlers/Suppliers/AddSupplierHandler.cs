using Components.SupplierManagementApi.Requests;
using Components.SupplierManagementApi.Services.Suppliers;
using Microsoft.Extensions.Logging;
using SupplierManagementSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementSite.Core.Handlers.Suppliers
{
    public class AddSupplierHandler : IAddSupplierHandler
    {
        private readonly ILogger<AddSupplierHandler> logger;
        private readonly ISupplierService supplierService;

        public AddSupplierHandler(ILogger<AddSupplierHandler> logger, ISupplierService supplierService)
        {
            this.logger = logger;
            this.supplierService = supplierService;
        }

        public async Task<AddSupplierResponse> Handle(Supplier model, CancellationToken cancellationToken)
        {
            AddSupplierResponse response = new();

            var result = await supplierService.Add(model, cancellationToken);
            if (!result.IsSuccess)
            {
                response.Message = $"Operation failed with status code {result.HttpStatusCode}";
                response.StatusCode = Enums.StatusCode.Error;
                return response;
            }

            response = result.Response;
            return response;
        }
    }
}
