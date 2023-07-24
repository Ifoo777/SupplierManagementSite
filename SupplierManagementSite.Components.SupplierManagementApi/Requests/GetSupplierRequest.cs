using Components.SupplierManagementApi.Models;
using SupplierManagementSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi.Requests
{
    public class GetSupplierRequest
    {
        public Query Query { get; set; } = new Query();
    }
}
