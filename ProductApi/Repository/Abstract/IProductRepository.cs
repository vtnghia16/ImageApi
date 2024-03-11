using ProductApi.Models.Domain;

namespace ProductApi.Repository.Abstract
{
    public interface IProductRepository
    {
        // Check the conditions before adding objects
        bool Add(Product model);
    }
}
