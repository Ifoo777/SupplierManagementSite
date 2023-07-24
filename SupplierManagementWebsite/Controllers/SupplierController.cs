using Components.SupplierManagementApi.Requests;
using Microsoft.AspNetCore.Mvc;
using SupplierManagementSite.Core.Handlers.Suppliers;
using SupplierManagementSite.Models;

namespace SupplierManagementWebsite.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IGetSupplierHandler getSupplierHandler;
        private readonly IAddSupplierHandler addSupplierHandler;

        public SupplierController(IGetSupplierHandler getSupplierHandler, IAddSupplierHandler addSupplierHandler)
        {
            this.getSupplierHandler = getSupplierHandler;
            this.addSupplierHandler = addSupplierHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string filter, CancellationToken cancellationToken)
        {
            var request = new GetSupplierRequest()
            {
                Query = new SupplierManagementSite.Models.Query()
                {
                    Filter = filter,
                    Skip = 0,
                    Take = 1000000
                }
            };
            var result = await getSupplierHandler.Handle(request, cancellationToken);
            return View(result.Suppliers);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(Supplier model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            var result = await addSupplierHandler.Handle(model, cancellationToken);
            if (!result.Success)
            {
                //Add handling here
                return View(model);
            }

            return RedirectToAction("Index");
        } 

    }
}
