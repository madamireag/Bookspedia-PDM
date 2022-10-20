
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Echipa07
{
    public class SearchBookViewModel : INotifyPropertyChanged
    {
        private List<Book> books;
        private string _searchTerm;

        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }
            set
            {
                _searchTerm = value; OnPropertyChanged(nameof(searchResults));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Book> _searchResults { get; set; }
        public ObservableCollection<Book> searchResults
        {
            get { return _searchResults; }
            set { _searchResults = value; OnPropertyChanged(nameof(searchResults)); }
        }

        public DelegateCommand<Book> ShowBookDetailCommand { get; }
        public DelegateCommand<Book> ItemAppearingCommand { get; }
        public ICommand SearchCommand => new Command<string>(InitializeazaListaCartiSearch);
        public SearchBookViewModel()
        {
            searchResults = new ObservableCollection<Book>();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InitializeazaListaCartiSearch(string SearchTerm)
        {
            try
            {
                Task.Run(async () => {
                    searchResults = await LoadSearchedBooks(SearchTerm);
                }).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private async Task<ObservableCollection<Book>> LoadSearchedBooks(string SearchTerm)
        {
            searchResults = new ObservableCollection<Book>();
            var books = await GoogleBooksService.GetBooksByTitle(SearchTerm);
            var list = books.Itemss;
            foreach (var book in list)
            {
                searchResults.Add(book);
            }
            return searchResults;

        }
    }
}