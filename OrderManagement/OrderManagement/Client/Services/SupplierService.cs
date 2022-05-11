using OrderManagement.Client.Interfaces;
using OrderManagement.Shared;
using OrderManagement.Shared.Entities;
using System.Net.Http.Json;

namespace OrderManagement.Client.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _http;

        public SupplierService(HttpClient http)
        {
            _http = http;
        }

        public List<Supplier> Suppliers { get; set; }
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var result = await _http.PostAsJsonAsync("api/supplier", supplier);
            var newSupplier = (await result.Content.ReadFromJsonAsync<ServiceResponse<Supplier>>()).Data;
            return newSupplier;
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Supplier>>>("api/supplier");
            return result.Data;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Supplier>>($"api/supplier/{id}");
            return result.Data;
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            var result = await _http.PutAsJsonAsync($"api/supplier", supplier);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Supplier>>();
            return content.Data;
        }

        public async Task DeleteSupplier(Supplier supplier)
        {
            var result = await _http.DeleteAsync($"api/supplier/{supplier.Id}");
        }
    }
}
