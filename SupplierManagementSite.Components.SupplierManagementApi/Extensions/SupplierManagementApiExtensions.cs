using Components.SupplierManagementApi.Services.Suppliers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi.Extensions
{
    public static class SupplierManagementApiExtensions
    {
        public static WebApplicationBuilder AddSupplierManagementApiExtensions(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IConnector, Connector>();
            webApplicationBuilder.Services.AddScoped<ISupplierService, SupplierService>();

            return webApplicationBuilder;
        }
    }
}
