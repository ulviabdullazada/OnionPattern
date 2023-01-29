using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Persistance.Repostories;

namespace TheCheckpoint.Presentation.Controllers
{
    public class HomeController : Controller
    {
        IProductReadRepository _productRead { get; }
        IProductWriteRepository _productWrite { get; }

        public HomeController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productRead = productReadRepository;
            _productWrite = productWriteRepository;
        }

        public IActionResult Index()
        {
            return Json(_productRead.GetAll());
        }
        public async Task<IActionResult> Add()
        {
            await _productWrite.CreateAllAsync(new()
            {
                new(){ Id = Guid.NewGuid(),Name = "P1", StockCount = 100, Price = 200},
                new(){ Id = Guid.NewGuid(),Name = "P2", StockCount = 200, Price = 200},
                new(){ Id = Guid.NewGuid(),Name = "P3", StockCount = 300, Price = 200}
            });
            await _productWrite.SaveAsync();
            return Ok();
        }
    }
}