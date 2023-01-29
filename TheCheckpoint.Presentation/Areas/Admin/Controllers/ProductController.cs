using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCheckpoint.Application.Abstracts.Storage;
using TheCheckpoint.Application.QueryParameters;
using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Application.ViewModels;
using TheCheckpoint.Domain.Entities;

namespace TheCheckpoint.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public ProductController(IProductReadRepository productRead, 
            IProductWriteRepository productWrite, 
            IStorageService storageService, 
            IProductImageFileWriteRepository productImageFileWrite, 
            IProductImageFileReadRepository productImageFileRead)
        {
            _productRead = productRead;
            _productWrite = productWrite;
            _storageService = storageService;
            _productImageFileWrite = productImageFileWrite;
            _productImageFileRead = productImageFileRead;
        }

        IProductReadRepository _productRead { get; }
        IProductWriteRepository _productWrite { get; }
        IStorageService _storageService { get; }
        IProductImageFileWriteRepository _productImageFileWrite { get; }
        IProductImageFileReadRepository _productImageFileRead { get; }


        public IActionResult Index(Pagination pagination)
        {
            var query = _productRead.GetAll(false);
            int pageCount = query.Count();
            if (pagination.Page* pagination.Take > pageCount) pagination.Page = 0;
            PaginatedList<Product> products = new PaginatedList<Product>()
            {
                PageCount = pageCount % pagination.Take == 0 ? pageCount / pagination.Take : pageCount / pagination.Take + 1,
                CurrentPage = pagination.Page,
                Datas = query.Skip(pagination.Page * pagination.Take).Take(pagination.Take).Include(p=>p.ProductImageFiles)
            };
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid) return View();
            Product product = new Product
            {
                Name = productCreateVM.Name,
                StockCount = productCreateVM.StockCount,
                Price = productCreateVM.Price,
                Discount = productCreateVM.Discount
            };


            string path = Path.Combine("imgs","product-images");
            productCreateVM.Images.Add(productCreateVM.CoverImage);
            List<string> names = await _storageService.UploadAsync(path, productCreateVM.Images);
            string lastImageName = names.LastOrDefault();
            names.Remove(lastImageName);


            await _productWrite.CreateAsync(product);
            await _productImageFileWrite.CreateAsync(new ProductImageFile
            {
                Name = lastImageName,
                Extension = Path.GetExtension(lastImageName),
                Product = product,
                Path = path,
                IsCover = true
            });
            foreach (string name in names)
            {
                await _productImageFileWrite.CreateAsync(new ProductImageFile
                {
                    Name = name,
                    Extension = Path.GetExtension(name),
                    Product = product,
                    Path = path,
                    IsCover = false
                });
            }
            await _productWrite.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string id)
        {
            _productWrite.Delete(id);
            await _productWrite.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(string? id)
        {
            return View(await _productRead.Table.Include(p=>p.ProductImageFiles).FirstOrDefaultAsync(p=>p.Id == Guid.Parse(id)));
        }
    }
}
