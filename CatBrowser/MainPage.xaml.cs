using CatBrowser.ViewModel;

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
            await viewModel.GetCatImagesAsync();
        }
    }

}
