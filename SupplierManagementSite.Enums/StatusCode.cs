using System.Text.Json.Serialization;

namespace SupplierManagementSite.Enums
{
    public enum StatusCode
    {
        None = 0,
        Success = 1,
        ValidationsFailure = 2,
        Error = 3
    }
}