using exercise.wwwapi.Model;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Product?> GetProducts(string category);
        Product addProduct(ProductPost car);
        //Product UpdateCar(int id, CarPut carPut);
        Product? GetAProduct(int id);

        Product? UpdateProduct(int id, ProductPut put);

        Product? DeleteProduct(int id);
    }
}
