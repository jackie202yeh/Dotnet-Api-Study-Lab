using Repository.Conditions;
using Repository.Interfaces;
using Service.Dtos;
using Service.InfoModel;
using Service.Interfaces;

namespace Service.Implements;

/// <summary>
/// 產品服務
/// </summary>
/// <seealso cref="Service.Interfaces.IProductService" />
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// ctor
    /// </summary>
    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    /// <summary>
    /// 根據Id查詢產品
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<SearchProductDto> GetByIdAsync(int id)
    {
        var dataModel = await this._productRepository.GetByIdAsync(id);
        var dto = new SearchProductDto
        {
            ProductId = dataModel.ProductId,
            ProductName = dataModel.ProductName,
            SupplierName = dataModel.SupplierName,
            CategoryName = dataModel.CategoryName,
            QuantityPerUnit = dataModel.QuantityPerUnit,
            UnitPrice = dataModel.UnitPrice,
            UnitsInStock = dataModel.UnitsInStock,
            UnitsOnOrder = dataModel.UnitsOnOrder,
            ReorderLevel = dataModel.ReorderLevel,
            Discontinued = dataModel.Discontinued
        };

        return dto;
    }

    /// <summary>
    /// 產品新增
    /// </summary>
    /// <param name="infoModel">The information model.</param>
    /// <returns></returns>
    public async Task<int> CreateAsync(ProductCreateInfoModel infoModel)
    {
        var condition = new ProductCreateCondition
        {
            ProductName = infoModel.ProductName,
            SupplierId = infoModel.SupplierId,
            CategoryId = infoModel.CategoryId,
            QuantityPerUnit = infoModel.QuantityPerUnit,
            UnitPrice = infoModel.UnitPrice,
            UnitsInStock = infoModel.UnitsInStock,
            UnitsOnOrder = infoModel.UnitsOnOrder,
            ReorderLevel = infoModel.ReorderLevel,
            Discontinued = infoModel.Discontinued
        };

        var id = await this._productRepository.CreateAsync(condition);

        return id;
    }

    /// <summary>
    /// 產品更新
    /// </summary>
    /// <param name="infoModel">The information model.</param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(ProductUpdateInfoModel infoModel)
    {
        var condition = new ProductUpdateCondition
        {
            ProductId = infoModel.ProductId,
            ProductName = infoModel.ProductName,
            SupplierId = infoModel.SupplierId,
            CategoryId = infoModel.CategoryId,
            QuantityPerUnit = infoModel.QuantityPerUnit,
            UnitPrice = infoModel.UnitPrice,
            ReorderLevel = infoModel.ReorderLevel,
            Discontinued = infoModel.Discontinued
        };

        return await this._productRepository.UpdateAsync(condition);
    }

    /// <summary>
    /// 產品刪除
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(int id)
    {
        return await this._productRepository.DeleteAsync(id);
    }
}