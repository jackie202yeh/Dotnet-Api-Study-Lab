namespace Repository.DataModels;

public class ResultList<TDataModel>
{
    public IEnumerable<TDataModel> result { get; set; }

    public int Total {  get; set; }
}
