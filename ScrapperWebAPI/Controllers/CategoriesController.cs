using Microsoft.AspNetCore.Mvc;
using ScrapperWebAPI.Helpers;

namespace ScrapperWebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get(string store)
    {
        if (store.ToLower() == "gosport")
        {
            var data = await GetGoSportBrands.GetAll();
            return Ok(data);
        }
        else if (store.ToLower() == "zara")
        {
            var data = await GetZaraCategories.GetAll();
            return Ok(data);
        }
        return BadRequest("Store not found");
    }
}
