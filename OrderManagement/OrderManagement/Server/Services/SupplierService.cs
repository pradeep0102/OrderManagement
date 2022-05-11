using Microsoft.EntityFrameworkCore;
using OrderManagement.Server.Data;
using OrderManagement.Server.Interfaces;
using OrderManagement.Shared;
using OrderManagement.Shared.Entities;

namespace OrderManagement.Server.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly DataContext _context;
        public SupplierService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Supplier>> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Supplier> { Data = supplier };
        }

        public async Task<ServiceResponse<bool>> DeleteSupplier(int id)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(id);
            if (dbSupplier == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Supplier not found."
                };
            }

            dbSupplier.IsDeleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Supplier>>> GetAllSuppliers()
        {
            var suppliers = await _context.Suppliers.Where(a => !a.IsDeleted).ToListAsync();
            return new ServiceResponse<List<Supplier>> { Data = suppliers };
        }

        public async Task<ServiceResponse<Supplier>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(a => a.Id == id);
            return new ServiceResponse<Supplier> { Data = supplier };
        }

        public async Task<ServiceResponse<Supplier>> UpdateSupplier(Supplier supplier)
        {
            var dbSupplier = await _context.Suppliers.FindAsync(supplier.Id);
            if (dbSupplier == null)
            {
                return new ServiceResponse<Supplier>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbSupplier.Name = supplier.Name;
            dbSupplier.AddressLine1 = supplier.AddressLine1;
            dbSupplier.AddressLine2 = supplier.AddressLine2;
            dbSupplier.PostalCode = supplier.PostalCode;
            dbSupplier.State = supplier.State;
            dbSupplier.City = supplier.City;
            await _context.SaveChangesAsync();
            return new ServiceResponse<Supplier> { Data = supplier };
        }
    }
}
