using Microsoft.AspNetCore.Mvc;
using Service.InfoModel;
using Service.Interfaces;
using WebApi.Parameters;
using WebApi.ViewModel;

namespace API.Controllers
{
    /// <summary>
    /// 產品Api
    /// </summary>
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// 單一產品查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var dto = await this._productService.GetByIdAsync(id);

            var viewModel = new ProductSearchViewModel
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                SupplierName = dto.SupplierName,
                CategoryName = dto.CategoryName,
                QuantityPerUnit = dto.QuantityPerUnit,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                UnitsOnOrder = dto.UnitsOnOrder,
                ReorderLevel = dto.ReorderLevel,
                Discontinued = dto.Discontinued
            };

            return this.Ok(viewModel);
        }

        /// <summary>
        /// 產品新增
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateParameter parameter)
        {
            var infoModel = new ProductCreateInfoModel
            {
                ProductName = parameter.ProductName,
                SupplierId = parameter.SupplierId,
                CategoryId = parameter.CategoryId,
                QuantityPerUnit = parameter.QuantityPerUnit,
                UnitPrice = parameter.UnitPrice,
                UnitsInStock = parameter.UnitsInStock,
                UnitsOnOrder = parameter.UnitsOnOrder,
                ReorderLevel = parameter.ReorderLevel,
                Discontinued = parameter.Discontinued
            };
            var result = await this._productService.CreateAsync(infoModel);
            return this.Ok(result);
        }

        /// <summary>
        /// 產品更新
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductUpdateParameter parameter)
        {
            var infoModel = new ProductUpdateInfoModel
            {
                ProductId = parameter.ProductId,
                ProductName = parameter.ProductName,
                SupplierId = parameter.SupplierId,
                CategoryId = parameter.CategoryId,
                QuantityPerUnit = parameter.QuantityPerUnit,
                UnitPrice = parameter.UnitPrice,
                ReorderLevel = parameter.ReorderLevel,
                Discontinued = parameter.Discontinued
            };

            var result = await this._productService.UpdateAsync(infoModel);

            return this.Ok(result);
        }

        /// <summary>
        /// 產品刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await this._productService.DeleteAsync(id);
            return result ? this.Ok("Success") : (IActionResult)this.Ok("Fail");
        }
    }
}