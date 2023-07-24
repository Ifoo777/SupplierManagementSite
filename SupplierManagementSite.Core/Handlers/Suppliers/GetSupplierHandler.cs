using Components.SupplierManagementApi.Requests;
using Components.SupplierManagementApi.Services.Suppliers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagementSite.Core.Handlers.Suppliers
{
    public class GetSupplierHandler : IGetSupplierHandler
    {
        private readonly ILogger<GetSupplierHandler> logger;
        private readonly ISupplierService supplierService;

        public GetSupplierHandler(ILogger<GetSupplierHandler> logger, ISupplierService supplierService)
        {
            this.logger = logger;
            this.supplierService = supplierService;
        }

        public async Task<GetSupplierResponse> Handle(GetSupplierRequest request, CancellationToken cancellationToken)
        {
            GetSupplierResponse response = new();

            var result = await supplierService.Get(request.Query, cancellationToken);
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
