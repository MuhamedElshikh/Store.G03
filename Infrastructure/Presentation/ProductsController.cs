using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
    {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
        {

        [HttpGet]
   
        
        public async Task<ActionResult<PaginationResponse<ProductResultDto>>> GetAllProducts([FromQuery] ProductSpecificationsParameters productSpecsParams)
        {
            var result = await serviceManager.ProductService.GetAllProductsAsync(productSpecsParams);
            return Ok(result);
        }


        //api/products/1
        [HttpGet("{id}")]
       

        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
        {
            var result = await serviceManager.ProductService.GetProductByIdAsync(id);

            if (result == null) throw new Exception("Not Found");

            return Ok(result);
        }


        //api/products/brands
        [HttpGet("brands")]
       

        public async Task<ActionResult<BrandResultDto>> GetAllBrands()
        {
            var result = await serviceManager.ProductService.GetAllBrandsAsync();
            if (result == null) return BadRequest();
            return Ok(result);
        }


        //api/products/types
        [HttpGet("types")]
      

        public async Task<ActionResult<TypeResultDto>> GetAllTypes()
        {
            var result = await serviceManager.ProductService.GetAllTypesAsync();
            if (result == null) return BadRequest();
            return Ok(result);
        }

    }
}
