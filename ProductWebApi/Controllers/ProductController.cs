using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Model;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _dbContext.Products;
        }

        [HttpGet("{ProductId:int}")]
        public async Task<ActionResult<Product>> GetById(int ProductId)
        {
            var Product = await _dbContext.Products.FindAsync(ProductId);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product Product)
        {
            await _dbContext.Products.AddAsync(Product);
            await _dbContext.SaveChangesAsync();
            return Ok(Product);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product Product)
        {
            _dbContext.Products.Update(Product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{ProductId:int}")]
        public async Task<ActionResult> Delete(int ProductId)
        {
            var Product = await _dbContext.Products.FindAsync(ProductId);
            _dbContext.Products.Remove(Product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
