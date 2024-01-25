using exercise.wwwapi.Data;
using exercise.wwwapi.Model;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext data)
        {
            _db = data;
        }
        public IEnumerable<Product?> GetProducts(string? category)
        {
            if (category != null)
            {
                return _db.Products.Where(p => p.Category == category);
            }
            return _db.Products.ToList();
        }

        public Product addProduct(ProductPost product)
        {
            Product prod = new Product(){Category = product.Category, Name = product.Name, Price = product.Price};
            _db.Products.Add(prod);
            _db.SaveChanges();
            return prod;
        }

        public Product? GetAProduct(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product? UpdateProduct(int id, ProductPut put)
        {
            Product prod = GetAProduct(id);
            if (prod == null) return null;

            prod.Name = put.Name;
            prod.Price = put.Price;
            prod.Category = put.Category;
            _db.SaveChanges();

            return prod;
        }

        public Product? DeleteProduct(int id)
        {
            Product prod = GetAProduct(id);
            if (prod == null) return null;

            _db.Products.Remove(prod);
            _db.SaveChanges();

            return prod;
        }
    }
}
