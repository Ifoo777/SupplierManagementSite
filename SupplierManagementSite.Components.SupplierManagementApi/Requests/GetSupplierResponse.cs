using Components.SupplierManagementApi.Models;
using SupplierManagementSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi.Requests
{
    public class GetSupplierResponse : BaseResponse
    {
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
