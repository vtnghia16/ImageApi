namespace ProductApi.Repository.Abstract
{
    public interface IFileService
    {
        // Tuple save value (int, string)
        public Tuple<int, string> SaveImage(IFormFile imageFile);
    }
}
