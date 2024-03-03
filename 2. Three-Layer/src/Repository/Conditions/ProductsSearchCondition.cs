namespace Repository.Conditions;
/// <summary>
/// 產品查詢參數
/// </summary>
public class ProductsSearchCondition
{
    /// <summary>
    /// 產品名稱
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 供應商Id
    /// </summary>
    public int CompanyId { get; set; }

    public int CategoryId { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }
}
