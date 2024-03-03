using Service.Dtos;
using Service.InfoModel;

namespace Service.Interfaces;

public interface IProductService
{
    /// <summary>
    /// 產品新增
    /// </summary>
    /// <param name="infoModel">The information model.</param>
    /// <returns></returns>
    Task<int> CreateAsync(ProductCreateInfoModel infoModel);

    /// <summary>
    /// 產品刪除
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// 根據Id查詢產品
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<SearchProductDto> GetByIdAsync(int id);

    /// <summary>
    /// 產品更新
    /// </summary>
    /// <param name="infoModel">The information model.</param>
    /// <returns></returns>
    Task<bool> UpdateAsync(ProductUpdateInfoModel infoModel);
}