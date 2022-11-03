
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
    public class SearchBookViewModel : BindableBase,INotifyPropertyChanged
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
        private Book _book;
        public static List<Book> Books = new List<Book>();

        public ICommand AddToFavoritesCommand => new Command<Book>(ExecuteAddToFavoritesCommand);
        public void ExecuteAddToFavoritesCommand(Book book)
        {

            try
            {
                Task.Run(async () => {
                    if (!Books.Any(id => id.Id == this.Book.Id))
                    {
                        Books.Add(this.Book);
                    }
                }).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
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
        public static void CheckBook(Book book)
        {
            if (book.VolumeInfo.ImageLinks == null)
            {
                book.VolumeInfo.ImageLinks = new ImageLinks();
                book.VolumeInfo.ImageLinks.SmallThumbnail = new Uri("https://www.nicepng.com/png/detail/10-104761_books-png-image-school-pinterest-images-transparent-background.png").ToString();
            }
            if (book.SaleInfo.Saleability.Equals("NOT_FOR_SALE"))
            {
                book.SaleInfo.RetailPrice = new RetailPrice();
                book.SaleInfo.RetailPrice.Amount = "Not For Sale";
                book.SaleInfo.RetailPrice.CurrencyCode = "";
            }
            if(book.VolumeInfo.AverageRating == null)
            {
                book.VolumeInfo.AverageRating = new String("No Rating");
                
            }
            if(book.VolumeInfo.Description != null)
            {
                if(book.VolumeInfo.Description.Contains("<br>"))
                {
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("<br>", "");
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("</br>", "");
                }
                if (book.VolumeInfo.Description.Contains("<p>"))
                {
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("<p>", Environment.NewLine);
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("</p>", Environment.NewLine);
                }
                if (book.VolumeInfo.Description.Contains("<b>"))
                {
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("<b>", "");
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("</b>", "");
                }
                if (book.VolumeInfo.Description.Contains("<i>"))
                {
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("<i>", "");
                    book.VolumeInfo.Description = book.VolumeInfo.Description.Replace("</i>", "");
                }
            }
        }
        private async Task<ObservableCollection<Book>> LoadSearchedBooks(string SearchTerm)
        {
            searchResults = new ObservableCollection<Book>();
            var books = await GoogleBooksService.GetBooksByTitle(SearchTerm);
            var list = books.Itemss;
            foreach (var book in list)
            {
                CheckBook(book); 
                searchResults.Add(book);
            }
            return searchResults;

        }
    }
}