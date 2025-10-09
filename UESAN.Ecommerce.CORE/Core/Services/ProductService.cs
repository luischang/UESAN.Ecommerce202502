using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.CORE.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProductsAll()
        {
            var products = await _productRepository.GetProducts();
            var productDTOS = new List<ProductListDTO>();

            foreach (var product in products)
            {
                var productDTO = new ProductListDTO();
                productDTO.Id = product.Id;
                productDTO.Description = product.Description;
                productDTOS.Add(productDTO);
            }

            return productDTOS;
        }

        public async Task<ProductListDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            var productDTO = new ProductListDTO();
            productDTO.Id = product.Id;
            productDTO.Description = product.Description;

            return productDTO;
        }

        public async Task<int> InsertProduct(ProductCreateDTO productCreateDTO)
        {
            var product = new Product();
            product.Description = productCreateDTO.Description;
            product.IsActive = true;  // Por defecto, al crear una categoría, se establece como activa.
            var newProductId = await _productRepository.InsertProduct(product);
            return newProductId;
        }

        public async Task UpdateProduct(ProductListDTO productListDTO)
        {
            var product = new Product();
            product.Id = productListDTO.Id;
            product.Description = productListDTO.Description;
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductListDTO>> GetAllProducts()
        {
            return await GetProductsAll();
        }
    }
}
