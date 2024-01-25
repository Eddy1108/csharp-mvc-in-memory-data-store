using exercise.wwwapi.Model;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ProductEndpoint
    {
        public static void ConfigureProductEndpoint(this WebApplication app)
        {
            var productGroup = app.MapGroup("products");

            productGroup.MapGet("/getAll", GetProducts);
            productGroup.MapPost("/AddProduct/{Product}", AddProduct);
            productGroup.MapGet("/getAProduct/{id}", GetProduct);
            productGroup.MapPut("/update/{id}", UpdateProduct);
            productGroup.MapDelete("/delete/{id}", DeleteProduct);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetProducts(IRepository repository, string? category)
        {
            return TypedResults.Ok(repository.GetProducts(category));
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddProduct(IRepository repository, ProductPost product)
        {
            //if (int.TryParse(product.Name))
            //{

            //}
            return TypedResults.Ok(repository.addProduct(product));
        }   
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetProduct(IRepository repository, int id)
        {
            Product? prod = repository.GetAProduct(id);
            if (prod != null)
            {
                return TypedResults.Ok(prod);
            }

            return TypedResults.BadRequest("Invalid ID: No matching items");
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> UpdateProduct(IRepository repository, int id, ProductPut put)
        {
            Product? prod = repository.UpdateProduct(id, put);
            if (prod != null)
            {
                return TypedResults.Ok(prod);
            }

            return TypedResults.BadRequest("Invalid ID: No matching items");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteProduct(IRepository repository, int id)
        {
            Product? prod = repository.DeleteProduct(id);
            if (prod != null)
            {
                return TypedResults.Ok(prod);
            }
            
            return TypedResults.BadRequest("Invalid ID: No matching items");
        }
    }
}
