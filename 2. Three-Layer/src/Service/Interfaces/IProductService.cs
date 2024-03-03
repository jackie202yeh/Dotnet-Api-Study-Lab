using Service.Dtos;
using Service.InfoModel;

namespace Service.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductCreateInfoModel infoModel);

        Task<bool> DeleteAsync(int id);

        Task<SearchProductDto> GetByIdAsync(int id);

        Task<bool> UpdateAsync(ProductUpdateInfoModel infoModel);
    }
}