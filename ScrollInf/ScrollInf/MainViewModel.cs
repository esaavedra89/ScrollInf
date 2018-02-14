﻿
namespace ScrollInf
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Xamarin.Forms.Extended;

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy;
        private const int PageSize = 10;
        private DataService _dataService = new DataService();
        public InfiniteScrollCollection<string> Items { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Items = new InfiniteScrollCollection<string>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var page = Items.Count / PageSize;
                    //Obtiene la lista
                    var items = await _dataService.GetItemsAsync(page, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                },
                OnCanLoadMore = () =>
                {
                    return Items.Count < 44;
                }
            };
            DownloadDataAsync();
        }
        private async Task DownloadDataAsync()
        {
            var items = await _dataService.GetItemsAsync(pageIndex: 0, pageSize: PageSize);

            Items.AddRange(items);
        }


    }
}
