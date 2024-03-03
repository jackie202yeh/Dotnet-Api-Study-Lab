namespace API.Parameters;

/// <summary>
/// 產品查詢Parameter
/// </summary>
public class ProductsSearchParameter
{
    /// <summary>
    /// 產品名稱
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 供應商名稱
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// 類別名稱
    /// </summary>
    /// <value>
    /// The name of the category.
    /// </value>
    public string CategoryName { get; set; }

    /// <summary>
    /// 最低價格
    /// </summary>
    public int? MinPrice { get; set; }

    /// <summary>
    /// 最高價格
    /// </summary>
    public int? MaxPrice { get; set; }
}