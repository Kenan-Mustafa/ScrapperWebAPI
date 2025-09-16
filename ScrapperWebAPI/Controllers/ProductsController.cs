using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrapperWebAPI.Helpers;
using ScrapperWebAPI.Helpers.Product;
using ScrapperWebAPI.Models.GoSport;
using ScrapperWebAPI.Models.ProductDtos;

namespace ScrapperWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string store,string category)
        {
            var a = await GetZaraProduct.GetByCategoryName(category);
            return Ok(a);
            if (store.ToLower() == "gosport")
            {
                var data = await GetGoSportProducts.GetByProductByBrand(category);
                return Ok(data);
            }
            else if (store.ToLower() == "zara")
            {
                var data = await GetZaraProduct.GetByCategoryName(category);
                return Ok(data);
            }
            return Ok("Hello from ProductsController");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(string store)
        {
            //var list = new HashSet<ProductToListDto>();
            //var categories = await GetZaraCategories.GetAll();

            //foreach (var category in  categories)
            //{
            //    var products = await GetZaraProduct.GetByCategoryName(category.Name);
            //    foreach (var product in products)
            //    {
            //        list.Add(product);
            //    }
            //}   


            var products = await GetZaraProduct.GetByCategoryName("MAN-ПРОСМОТРЕТЬ ВСЕ");
            return Ok(products.Count());
            //return Ok(list.Count());

        }
    }
}
