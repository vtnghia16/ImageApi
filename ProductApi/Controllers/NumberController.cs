using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models.Domain;
using ProductApi.Models.DTO;
using ProductApi.Repository.Abstract;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace ProductApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly IFileService _fileService;

        private readonly IProductRepository _productRepo;

        public NumberController(IFileService fs, IProductRepository productRepo)
        {
            this._fileService = fs;
            this._productRepo = productRepo;
        }

        [HttpPost]
        public IActionResult Add([FromForm] Product model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    // Get number from image file name and remove characters "#", ".jpg", ".png", ".jpeg"
                    string imageName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string numberPart = Regex.Match(imageName, @"\d+").Value;
                    model.ProductImage = numberPart;
                }
                var ImageResult = _productRepo.Add(model);
                if (ImageResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error";
                }
            }
            return Ok(new
            {
                message = status.Message,
                productImage = model.ProductImage
            });
        }
    }
}
