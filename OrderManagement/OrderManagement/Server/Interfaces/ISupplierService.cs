using OrderManagement.Shared;
using OrderManagement.Shared.Entities;

namespace OrderManagement.Server.Interfaces
{
    public interface ISupplierService
    {
        public Task<ServiceResponse<List<Supplier>>> GetAllSuppliers();
        public Task<ServiceResponse<Supplier>> AddSupplier(Supplier user);
        public Task<ServiceResponse<Supplier>> UpdateSupplier(Supplier user);
        public Task<ServiceResponse<Supplier>> GetSupplier(int id);
        public Task<ServiceResponse<bool>> DeleteSupplier(int id);
    }
}
