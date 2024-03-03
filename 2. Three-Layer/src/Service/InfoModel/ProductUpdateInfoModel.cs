namespace Service.InfoModel;

/// <summary>
/// 產品更新InfoModel
/// </summary>
public class ProductUpdateInfoModel
{
    /// <summary>
    /// 產品Id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 產品名稱
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 供應商Id
    /// </summary>
    public int? SupplierId { get; set; }

    /// <summary>
    /// 類別Id
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// 內容描述
    /// </summary>
    public string QuantityPerUnit { get; set; }

    /// <summary>
    /// 單價
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// 重新訂購等級
    /// </summary>
    public short ReorderLevel { get; set; }

    /// <summary>
    /// 停產
    /// </summary>
    public bool Discontinued { get; set; }
}