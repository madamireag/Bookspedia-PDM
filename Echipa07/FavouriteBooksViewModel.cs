using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class FavouriteBooksViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Book _book;
        public Book Book
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value; OnPropertyChanged(nameof(_book));
            }
        }
        public ObservableRangeCollection<Book> favoriteResults
        {
            get { return _favoriteResults; }
            set { _favoriteResults = value; OnPropertyChanged(nameof(favoriteResults)); }
        }

        public ObservableRangeCollection<Book> _favoriteResults { get; set; }

        public FavouriteBooksViewModel()
        {
            Title = "Favorite Books";
            favoriteResults = new ObservableRangeCollection<Book>();
            favoriteResults.AddRange(SearchBookViewModel.Books);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
