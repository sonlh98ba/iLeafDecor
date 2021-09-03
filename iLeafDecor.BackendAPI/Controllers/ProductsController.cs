using iLeafDecor.Application.Catalog.ProductImages;
using iLeafDecor.Application.Catalog.Products;
using iLeafDecor.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLeafDecor.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // http://localhost:port/products?pageIndex=1&pageSize=10&CategoryID=
        [HttpGet("{languageID}")]
        public async Task<IActionResult> GetAllPaging(string languageID, [FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryID(languageID, request);
            return Ok(products);
        }

        // http://localhost:port/product/public-paging/1
        [HttpGet("{productID}/{languageID}")]
        public async Task<IActionResult> GetByID(int productID, string languageID)
        {
            var product = await _manageProductService.GetByID(productID, languageID);
            if (product == null)
                return BadRequest("Can not find product!");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productID = await _manageProductService.Create(request);
            if (productID == 0)
            {
                return BadRequest();
            }

            var product = await _manageProductService.GetByID(productID, request.LanguageID);
            return CreatedAtAction(nameof(GetByID),new {id = productID} ,product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            var affectedResult = await _manageProductService.Delete(productID);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productID}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productID, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(productID, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        [HttpPost("{productID}/images")]
        public async Task<IActionResult> CreateImage(int productID, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageID = await _manageProductService.AddImage(productID, request);
            if (imageID == 0)
                return BadRequest();

            var image = await _manageProductService.GetImageByID(imageID);
            return CreatedAtAction(nameof(GetImageByID), new { id = imageID }, image);
        }

        [HttpPut("{productId}/images/{imageID}")]
        public async Task<IActionResult> UpdateImage(int imageID, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage(imageID, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{productID}/images/{imageID}")]
        public async Task<IActionResult> GetImageByID(int productID, int imageID)
        {
            var image = await _manageProductService.GetImageByID(imageID);
            if (image == null)
                return BadRequest("Can not find product!");
            return Ok(image);
        }
    }
}
