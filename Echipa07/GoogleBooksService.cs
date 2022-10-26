using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echipa07
{
    internal class GoogleBooksService
    {
        private const string baseURL = "https://www.googleapis.com/books/v1/volumes";
        private const string queryPath = "?q=";
        private const string apiKey = "AIzaSyBIInhunK4Ug0fW1bufWk8o5nzoiWZnQSg";

        public static async Task<Items> getAllBooks()
        {
            return await getBooks();
        }
        public static async Task<Items> GetBooksByTitle(string title)
        {
            return await getBooksDetailsByTitleAsync(title);
        }
        public static async Task<Items> getBooks()
        {

            var restUrl = $"{baseURL}{queryPath}subject:fiction&key={apiKey}&orderBy=newest&maxResults=12";
            HttpClient httpClient = new HttpClient();
            try
            {
                using (var response = await httpClient.GetAsync(restUrl).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            return JsonConvert.DeserializeObject<Items>(
                                await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return null;
        }

        public static async Task<Book> getBooksDetails(string id)
        {
            return await getBooksDetailsAsync(id);
        }

        public static async Task<Book> getBooksDetailsAsync(string id)
        {
            var restUrl = $"{baseURL}/{id}";
            HttpClient httpClient = new HttpClient();
            try
            {
                using (var response = await httpClient.GetAsync(restUrl).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            return JsonConvert.DeserializeObject<Book>(
                                await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return null;
        }
        public static async Task<Items> getBooksDetailsByTitleAsync(string title)
        {
            var restUrl = $"{baseURL}/{queryPath}/intitle:{title}";
            HttpClient httpClient = new HttpClient();
            try
            {
                using (var response = await httpClient.GetAsync(restUrl).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            return JsonConvert.DeserializeObject<Items>(
                                await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return null;
        }

        public static async Task<Items> getBooksCategories(string category)
        {
            var restUrl = $"{baseURL}{queryPath}/subject:{category}&maxResults=40";
            HttpClient httpClient = new HttpClient();
            try
            {
                using (var response = await httpClient.GetAsync(restUrl).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            return JsonConvert.DeserializeObject<Items>(
                                await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return null;
        }
    }
}
