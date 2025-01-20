using CatBrowser.Model;

namespace CatBrowser.View;

public partial class Details : ContentPage, IQueryAttributable
{
    public object SelectedImage { get; set; }

    public Details()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("SelectedImage"))
        {
            SelectedImage = query["SelectedImage"];

            // Set the BindingContext to the selected item
            BindingContext = SelectedImage;
        }
    }
}