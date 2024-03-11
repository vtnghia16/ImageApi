using ProductApi.Models.Domain;
using ProductApi.Repository.Abstract;

namespace ProductApi.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
		private readonly DatabaseContext _context;

		public ProductRepository(DatabaseContext context)
		{
			this._context = context;
		}

        public bool Add(Product model)
        {
			try
			{
				_context.Product.Add(model);
				_context.SaveChanges();
				return true;

			}
			catch (Exception ex)
			{

				return false;
			}
        }
    }
}
