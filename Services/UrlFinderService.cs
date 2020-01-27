using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetExamenam.Models;

namespace NetExamenam.Services
{
    public class UrlFinderService
    {
        private List<string> _existedUrls { get; set; }
        private string _hostUrl { get; set; }


        public UrlFinderService()
        {
            _existedUrls = new List<string>();
        }

        public async Task<List<UrlModel>> FindUrls(UrlFindModel urlFindModel)
        {
            if (urlFindModel.DepthLimit < 0 || urlFindModel.UrlsLimit < 0)
            {
                return new List<UrlModel>();
            }

            _hostUrl = urlFindModel.Url;
            var urls = await GetUrls(urlFindModel.Url, urlFindModel.UrlsLimit);

            _existedUrls.AddRange(urls.Select(x => x.Url).Distinct());

            urls.AddRange(await GetReferencedUrls(urls, urlFindModel.DepthLimit, urlFindModel.UrlsLimit));

            return urls;
        }

        private async Task<HtmlDocument> GetHtmlAsync(string url)
        {
            var htmlDocument = new HtmlDocument();
            using (var httpClient = new HttpClient())
            using (var res = await httpClient.GetAsync(url))
            using (var content = res.Content)
            {
                var data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    htmlDocument.LoadHtml(data);
                    return htmlDocument;
                }

                return null;
            }
        }

        private void ValidateUrl(UrlFindModel urlFindModel)
        {
            var regex = new Regex(@"/^(https?:\/\/)?([\w\.]+)\.([a-z]{2,6}\.?)(\/[\w\.]*)*\/?$/");
            if (!urlFindModel.Url.StartsWith("https://") || !urlFindModel.Url.StartsWith("http://"))
            {
                urlFindModel.Url = "https://" + urlFindModel.Url;
            }
        }

        private async Task<List<UrlModel>> GetReferencedUrls(List<UrlModel> urls, int depth, int urlsLimit)
        {
            if (depth <= 0)
            {
                return urls;
            }

            var resultUrls = new List<UrlModel>();

            foreach (var url in urls)
            {
                var childUrls = await GetUrls(url.Url, urlsLimit);

                _existedUrls.AddRange(childUrls.Select(x => x.Url).Distinct());
                
                resultUrls.AddRange(await GetReferencedUrls(childUrls, depth - 1, urlsLimit));
            }

            return resultUrls;
        }

        private async Task<List<UrlModel>> GetUrls(string url, int urlsLimit)
        {
            var html = await GetHtmlAsync(url);

            return html.DocumentNode.SelectNodes("//a[@href]")
                .Select(x => x.Attributes["href"].Value)
                .Where(x => !_existedUrls.Contains(x))
                .Where(x => x.StartsWith(_hostUrl) || !x.Contains("http"))
                .Distinct()
                .Take(urlsLimit)
                .Select(x => new UrlModel
                {
                    Url = x.Contains("http") ? x : url + x,
                    ParentUrl = url,
                    Body = html.DocumentNode.InnerText
                })
                .ToList();
        }
    }
}
