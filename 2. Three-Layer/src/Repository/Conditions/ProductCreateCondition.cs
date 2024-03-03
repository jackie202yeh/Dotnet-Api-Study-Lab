namespace Repository.Conditions;

public class ProductCreateCondition
{
    /// <summary>
    /// 產品名稱
    /// </summary>
    public string ProductName { get; set; } = null!;

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
    /// 庫存
    /// </summary>
    public short UnitsInStock { get; set; }

    /// <summary>
    /// 訂單數量
    /// </summary>
    public short UnitsOnOrder { get; set; }

    /// <summary>
    /// 重新訂購等級
    /// </summary>
    public short ReorderLevel { get; set; }

    /// <summary>
    /// 停產
    /// </summary>
    public bool Discontinued { get; set; }
}
