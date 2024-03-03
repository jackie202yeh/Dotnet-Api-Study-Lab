using Repository.Conditions;
using Repository.DataModels;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> DeleteAsync(int id);

        Task<ProductDataModel> GetByIdAsync(int id);

        Task<int> CreateAsync(ProductCreateCondition condition);

        Task<bool> UpdateAsync(ProductUpdateCondition condition);
    }
}