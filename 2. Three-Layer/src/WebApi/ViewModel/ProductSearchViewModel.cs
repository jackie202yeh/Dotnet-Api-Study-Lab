namespace WebApi.ViewModel;

/// <summary>
/// 產品查詢View Model
/// </summary>
public class ProductSearchViewModel
{
    /// <summary>
    /// 產品Id
    /// </summary>
    public int ProductId { get; set; } = 0;

    /// <summary>
    /// 產品名稱
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// 供應商名稱
    /// </summary>
    public string SupplierName { get; set; } = string.Empty;

    /// <summary>
    /// 類別名稱
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// 每一單位內容物
    /// </summary>
    public string QuantityPerUnit { get; set; }

    /// <summary>
    /// 單價
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// 庫存
    /// </summary>
    public short? UnitsInStock { get; set; }

    /// <summary>
    /// 訂單數量
    /// </summary>
    public short? UnitsOnOrder { get; set; }

    /// <summary>
    /// 重新訂購水平
    /// </summary>
    public short? ReorderLevel { get; set; }

    /// <summary>
    /// 停產
    /// </summary>
    public bool Discontinued { get; set; }
}