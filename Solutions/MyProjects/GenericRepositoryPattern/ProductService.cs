using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRespository)
        {
            _productRepository = productRespository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
