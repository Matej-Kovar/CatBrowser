using CatBrowser.ViewModel;
using CatBrowser.View;
using CatBrowser.Model;

namespace CatBrowser
{
    public partial class MainPage : ContentPage
    {
        CatBrowserViewModel viewModel;

        public MainPage(CatBrowserViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            this.viewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadMoreCatImagesAsync();
        }

        async void GoToDetails (object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                CatImage selectedImage = (CatImage)e.CurrentSelection.First();

                await Shell.Current.GoToAsync(nameof(Details), true, new Dictionary<string, object>
                {
                    { "SelectedImage", selectedImage }
                });

                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }

}
