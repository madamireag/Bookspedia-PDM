using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class BookDetailViewModel: BindableBase
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }
        public BookDetailViewModel(Book bookDetails)
        {
            Task.Run(async () => { await LoadBookDetailsAsync(bookDetails); }).Wait();
        }

        private async Task LoadBookDetailsAsync(Book book)
        {
            String bookId = book.Id;
            if (bookId != null)
            {
                var bookDetails = await GoogleBooksService.getBooksDetails(bookId).ConfigureAwait(false);
               
                if (bookDetails != null)
                {
                    SearchBookViewModel.CheckBook(bookDetails);
                    Book = bookDetails;
                }
            }
        }
    }
}
