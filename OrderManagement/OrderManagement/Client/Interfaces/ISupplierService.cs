using OrderManagement.Shared.Entities;

namespace OrderManagement.Client.Interfaces
{
    public interface ISupplierService
    {
        public Task<List<Supplier>> GetAllSuppliers();
        public Task<Supplier> AddSupplier(Supplier supplier);
        public Task<Supplier> UpdateSupplier(Supplier supplier);
        public Task<Supplier> GetSupplier(int id);
        public Task DeleteSupplier(Supplier supplier);
    }
}
