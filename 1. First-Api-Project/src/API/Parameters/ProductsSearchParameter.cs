namespace API.Parameters;

public class ProductsSearchParameter
{
    public string ProductName { get; set; }

    public string CompanyName { get; set; }

    public string CategoryName { get; set; }

    public int? minPrice { get; set; }

    public int? maxPrice { get; set; }
}
