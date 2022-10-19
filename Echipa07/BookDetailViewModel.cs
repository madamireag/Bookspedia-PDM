using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    public class BookDetailViewModel
    {
        public BookDetailViewModel(Book bookDetails)
        {
            //bookDetails e null ?nu stiu de ce
            Task.Run(async () => { await LoadBookDetailsAsync(bookDetails); }).Wait();
        }

        private async Task LoadBookDetailsAsync(Book book)
        {
            String bookId = book.Id;
            if (bookId != null)
            {
                var bookDetails = await GoogleBooksService.getBooksDetails(bookId).ConfigureAwait(false);

            }
        }
    }
}
