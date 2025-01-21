using CatBrowser.Model;
using CatBrowser.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CatBrowser.ViewModel
{
    public class CatBrowserViewModel
    {
        private CatGetter CatGetter;
        private bool isLoading = false;

        public ObservableCollection<CatImage> Cats { get; } = new ObservableCollection<CatImage>();

        public Command LoadMoreCommand { get; set; }

        public CatBrowserViewModel(CatGetter catGetter)
        {
            CatGetter = catGetter;
            LoadMoreCommand = new Command(async () => await LoadMoreCatImagesAsync());
        }

        public async Task LoadMoreCatImagesAsync()
        {
            if (isLoading) return;

            isLoading = true;
            var cats = await CatGetter.GetCatImages();
            foreach (var cat in cats)
            {
                if (!Cats.Any(existingCat => existingCat.Id == cat.Id))
                {
                    Cats.Add(cat);
                }

            }
            isLoading = false;
        }
    }
}
