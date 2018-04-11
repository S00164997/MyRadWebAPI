using Interest.Models;
using Interest.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetNewsPage : ContentPage
    {
        private string NewsSearchEndPoint = "https://api.cognitive.microsoft.com/bing/v7.0/news/search";
        public HttpClient BingNewsSearchClient
        {
            get;
            set;
        }
        public GetNewsPage(string newsSearch)
        {
            InitializeComponent();

            

            string newsSearchOne = newsSearch;
            DisplayAlert("Alert","Interest: "+newsSearchOne ,"Ok");
            BingNewsSearchClient = new HttpClient();
            BingNewsSearchClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "e38eb2f8b5d543f29ecfca57f9293dde");
            OnTextChangesEvent(newsSearchOne);
        }

        public async void OnTextChangesEvent(string query)
        {
            try
            {
                lstnews.ItemsSource = await GetNewsSearchResults(query);
            }//lstautosug
            catch (HttpRequestException)
            {

            }

        }

       


        public async Task<IEnumerable<NewsArticle>> GetNewsSearchResults(string query)
        {
            
            int count = 4;//amount of news data displayed
            int offset = 0;
            string market = "en-IE";//area of search results

            List<NewsArticle> articles = new List<NewsArticle>();
            var result = await RequestAndAutoRetryWhenThrottled(() => BingNewsSearchClient.GetAsync(string.Format("{0}/?q={1}&count={2}&offset={3}&mkt={4}", NewsSearchEndPoint, WebUtility.UrlEncode(query), count, offset, market)));
            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync();
            dynamic data = JObject.Parse(json);

            if (data.value != null && data.value.Count > 0)
            {
                for (int i = 0; i < data.value.Count; i++)
                {
                    articles.Add(new NewsArticle
                    {
                        Title = data.value[i].name,
                        Url = data.value[i].url,
                        Description = data.value[i].description,
                        ThumbnailUrl = data.value[i].image?.thumbnail?.contentUrl,
                        Provider = data.value[i].provider?[0].name
                    });
                }
            }


            return articles;
        }
        private async Task<HttpResponseMessage> RequestAndAutoRetryWhenThrottled(Func<Task<HttpResponseMessage>> action)
        {
            int retriesLeft = 6;
            int delay = 500;

            HttpResponseMessage response = null;

            while (true)
            {
                response = await action();

                if ((int)response.StatusCode == 429 && retriesLeft > 0)
                {
                    await Task.Delay(delay);
                    retriesLeft--;
                    delay *= 2;
                    continue;
                }
                else
                {
                    break;
                }
            }

            return response;
        }


    }
}