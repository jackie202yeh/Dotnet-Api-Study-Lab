using Repository.Conditions;
using Repository.DataModels;

namespace Repository.Interfaces;

/// <summary>
/// 產品Repository
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// 刪除產品
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// 根據Id查詢產品
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<ProductDataModel> GetByIdAsync(int id);

    /// <summary>
    /// 新增產品
    /// </summary>
    /// <param name="condition">The condition.</param>
    /// <returns></returns>
    Task<int> CreateAsync(ProductCreateCondition condition);

    /// <summary>
    /// 更新產品
    /// </summary>
    /// <param name="condition">The condition.</param>
    /// <returns></returns>
    Task<bool> UpdateAsync(ProductUpdateCondition condition);
}