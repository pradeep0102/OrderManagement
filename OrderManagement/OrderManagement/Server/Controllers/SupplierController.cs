using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Server.Interfaces;
using OrderManagement.Shared;
using OrderManagement.Shared.Entities;

namespace OrderManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Supplier>>> GetSupplier(int id)
        {
            var result = await _supplierService.GetSupplier(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Supplier>>>> GetSuppliers()
        {
            var result = await _supplierService.GetAllSuppliers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Supplier>>> AddSupplier(Supplier supplier)
        {
            var result = await _supplierService.AddSupplier(supplier);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Supplier>>> UpdateSupplier(Supplier supplier)
        {
            var result = await _supplierService.UpdateSupplier(supplier);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct(int id)
        {
            var result = await _supplierService.DeleteSupplier(id);
            return Ok(result);
        }


    }
}
