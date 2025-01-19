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
    public class CatBrowserViewModel : ViewModel
    {
        CatGetter CatGetter;

        public Command GetData {  get; set; }

        public ObservableCollection<CatImage> Cats { get; } = new ObservableCollection<CatImage>();

        public CatBrowserViewModel(CatGetter catGetter)
        {
            CatGetter = catGetter;
            GetData = new Command(async () => await GetCatImagesAsync());
        }

        public async Task GetCatImagesAsync()
        {
            var cats = await CatGetter.GetCatImages();

            foreach (var cat in cats)
            {
                Cats.Add(cat);
            }
        }
    }
}
