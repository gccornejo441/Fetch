
using System.Web;

namespace Fetch.Mobile.Views;

public partial class MyNewPage : ContentPage, IQueryAttributable
{
    private string _id {  get; set; }
	public MyNewPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, string> query)
    {
        if (query.ContainsKey("QueryId"))
        {
            _id = HttpUtility.UrlDecode(query["QueryId"]);
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }
}