using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Conditions;
using Repository.DataModels;
using Repository.Db;
using Repository.Interfaces;

namespace Repository.Implements;

public class ProductRepository : IProductRepository
{
    private readonly NorthwindContext _northwindContext;

    public ProductRepository(NorthwindContext northwindContext)
    {
        this._northwindContext = northwindContext;
    }

    public async Task<ProductDataModel> GetByIdAsync(int id)
    {
        var data = from p in this._northwindContext.Products
                   where p.ProductId == id
                   select p;

        var result = await data.Select(ProductDataModelSelector()).FirstOrDefaultAsync();

        return result;
    }

    public async Task<int> CreateAsync(ProductCreateCondition condition)
    {
        var product = this.ParseToProduct(condition);

        this._northwindContext.Products.Add(product);
        await this._northwindContext.SaveChangesAsync();

        return product.ProductId;
    }

    public async Task<bool> UpdateAsync(ProductUpdateCondition condition)
    {
        var update = await (from p in this._northwindContext.Products
                            where p.ProductId == condition.ProductId
                            select p).SingleOrDefaultAsync();

        if (update is null)
        {
            return false;
        }

        UpdateProduct(condition, update);
        await this._northwindContext.SaveChangesAsync();
        return true;
    }

    private static void UpdateProduct(ProductUpdateCondition condition, Product update)
    {
        update.ProductName = condition.ProductName;
        update.SupplierId = condition.SupplierId;
        update.CategoryId = condition.CategoryId;
        update.QuantityPerUnit = condition.QuantityPerUnit;
        update.UnitPrice = condition.UnitPrice;
        update.ReorderLevel = condition.ReorderLevel;
        update.Discontinued = condition.Discontinued;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await (from p in this._northwindContext.Products
                            where p.ProductId == id
                            select p).SingleOrDefaultAsync();

        if (delete is null)
        {
            return false;
        }

        this._northwindContext.Products.Remove(delete);
        await this._northwindContext.SaveChangesAsync();
        return true;
    }

    private Product ParseToProduct(ProductCreateCondition condition)
    {
        return new Product
        {
            ProductName = condition.ProductName,
            SupplierId = condition.SupplierId,
            CategoryId = condition.CategoryId,
            QuantityPerUnit = condition.QuantityPerUnit,
            UnitPrice = condition.UnitPrice,
            UnitsInStock = condition.UnitsInStock,
            UnitsOnOrder = condition.UnitsOnOrder,
            ReorderLevel = condition.ReorderLevel,
            Discontinued = condition.Discontinued,
            Category = this._northwindContext.Categories.Find(condition.CategoryId),
            Supplier = this._northwindContext.Suppliers.Find(condition.SupplierId)
        };
    }

    private static Expression<Func<Product, ProductDataModel>> ProductDataModelSelector()
    {
        return o => new ProductDataModel
        {
            ProductId = o.ProductId,
            ProductName = o.ProductName,
            QuantityPerUnit = o.QuantityPerUnit,
            UnitPrice = o.UnitPrice,
            UnitsInStock = o.UnitsInStock,
            UnitsOnOrder = o.UnitsOnOrder,
            Discontinued = o.Discontinued
        };
    }
}