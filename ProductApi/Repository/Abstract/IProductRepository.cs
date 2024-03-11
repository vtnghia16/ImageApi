using ProductApi.Models.Domain;

namespace ProductApi.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(Product model);
    }
}
