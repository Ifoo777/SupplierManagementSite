using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.SupplierManagementApi.Extensions;
using SupplierManagementSite.Core.Handlers.Suppliers;

namespace SupplierManagementSite.Core.Extensions
{
    public static class SupplierManagementApiExtensions
    {
        public static WebApplicationBuilder AddSupplierManagementSiteExtensions(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.AddSupplierManagementApiExtensions();
            webApplicationBuilder.Services.AddScoped<IGetSupplierHandler, GetSupplierHandler>();
            webApplicationBuilder.Services.AddScoped<IAddSupplierHandler, AddSupplierHandler>();

            return webApplicationBuilder;
        }
    }
}
