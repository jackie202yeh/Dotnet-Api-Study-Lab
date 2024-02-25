using API.Dtos;
using API.Models;
using API.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>
    /// 產品Api
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="northwindContext"></param>
        public ProductController(NorthwindContext northwindContext)
        {
            this._northwindContext = northwindContext;
        }

        /// <summary>
        /// 產品查詢
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListAsync(ProductsSearchParameter parameter)
        {
            var repository =
               (from p in this._northwindContext.Products
                join s in this._northwindContext.Suppliers on p.SupplierId equals s.SupplierId
                join c in this._northwindContext.Categories on p.CategoryId equals c.CategoryId
                select new ProductsList
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierName = s.CompanyName,
                    CategoryName = c.CategoryName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    Discontinued = p.Discontinued
                });
            // 搜尋產品名稱
            if (!string.IsNullOrWhiteSpace(parameter.ProductName))
            {
                repository = repository.Where(a => a.ProductName.Contains(parameter.ProductName));
            }
            // 搜尋供應商名稱
            if (!string.IsNullOrWhiteSpace(parameter.CompanyName))
            {
                repository = repository.Where(a => a.SupplierName.Contains(parameter.CompanyName));
            }
            // 搜尋類別名稱
            if (!string.IsNullOrWhiteSpace(parameter.CategoryName))
            {
                repository = repository.Where(a => a.CategoryName.Contains(parameter.CategoryName));
            }
            // 處理價格最大最小值範圍
            var _minPrice = 0;
            var _maxPrice = 2147483647;
            if (parameter.minPrice != null)
            {
                _minPrice = (int)parameter.minPrice;
            }
            if (parameter.maxPrice != null)
            {
                _maxPrice = (int)parameter.maxPrice;
            }
            repository = repository.Where(a => a.UnitPrice>= _minPrice && a.UnitPrice <= _maxPrice);
            var results = await repository.ToListAsync();
            return this.Ok(results);
        }

        /// <summary>
        /// 單一產品查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result =   from p in this._northwindContext.Products
                           where p.ProductId == id
                           join s in this._northwindContext.Suppliers on p.SupplierId equals s.SupplierId
                           join c in this._northwindContext.Categories on p.CategoryId equals c.CategoryId
                           select new ProductsList
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               SupplierName = s.CompanyName,
                               CategoryName = c.CategoryName,
                               QuantityPerUnit = p.QuantityPerUnit,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock,
                               UnitsOnOrder = p.UnitsOnOrder,
                               Discontinued = p.Discontinued
                           };
            return this.Ok(result);
        }

        /// <summary>
        /// 產品新增
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateParameter value)
        {
            // 檢查SupplierID和CategoryID是否存在於資料庫中
            var existingSupplier = this._northwindContext.Suppliers.FirstOrDefault(s => s.SupplierId == value.SupplierId);
            var existingCategory = this._northwindContext.Categories.FirstOrDefault(c => c.CategoryId == value.CategoryId);

            if (existingSupplier == null)
            {
                var validationErrors = new
                {
                    Message = "供應商不存在！"
                };
                return this.UnprocessableEntity(validationErrors);
            }
            else if (existingCategory == null)
            {
                var validationErrors = new
                {
                    Message = "類別不存在！"
                };
                return this.UnprocessableEntity(validationErrors);
            }
            else
            {
                var New_Product = new Product
                {
                    ProductName     = value.ProductName,
                    SupplierId      = value.SupplierId,
                    CategoryId      = value.CategoryId,
                    QuantityPerUnit = value.QuantityPerUnit,
                    UnitPrice       = value.UnitPrice,
                    UnitsInStock    = value.UnitsInStock,
                    UnitsOnOrder    = value.UnitsOnOrder,
                    ReorderLevel    = value.ReorderLevel,
                    Discontinued    = value.Discontinued,
                    Category        = this._northwindContext.Categories.Find(value.CategoryId),
                    Supplier        = this._northwindContext.Suppliers.Find(value.SupplierId)
                };

                this._northwindContext.Products.Add(New_Product);
                this._northwindContext.SaveChanges();
                return this.Ok("完成，產品編號：" + New_Product.ProductId.ToString());
            }
        }

        /// <summary>
        /// 產品更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("ProductName/{id}")]
        public IActionResult Put(int id, [FromBody] ProductUpdateParameter value)
        {
            if (id != value.ProductId)
            {
                return this.BadRequest();
            }
            var update = (from p in this._northwindContext.Products
                          where p.ProductId == id
                          select p).SingleOrDefault();

            if (update != null)
            {
                update.ProductName = value.ProductName;
                update.SupplierId = value.SupplierId;
                update.CategoryId = value.CategoryId;
                update.QuantityPerUnit = value.QuantityPerUnit;
                update.UnitPrice = value.UnitPrice;
                update.UnitsInStock = value.UnitsInStock;
                update.UnitsOnOrder = value.UnitsOnOrder;
                update.ReorderLevel = value.ReorderLevel;
                update.Discontinued = value.Discontinued;
                this._northwindContext.SaveChanges();
            }
            else
            {
                return this.NotFound();
            }

            return this.NoContent();
        }

        /// <summary>
        /// 產品刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = (from p in this._northwindContext.Products
                          where p.ProductId == id
                          select p).SingleOrDefault();
            if (delete != null)
            {
                this._northwindContext.Products.Remove(delete);
                this._northwindContext.SaveChanges();
            }
            else
            {
                return this.NotFound("找不到指定資源");
            }
            return this.NoContent();
        }
    }
}
