using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyWebApplication.Models
{
    public class ParsingURL
    {
        private HttpClient _httpClient;
        private HtmlDocument _htmlDocument;
        private readonly string _url;



        public ParsingURL(string url)
        {
            _url = url;
            _httpClient = new HttpClient();
            _htmlDocument = new HtmlDocument();
            var html = _httpClient.GetStringAsync(url).Result;
            _htmlDocument.LoadHtml(html);
        }

        public string GetElementString(string xpath)
        {
            var element = _htmlDocument.DocumentNode.SelectSingleNode(xpath);
            var el = element.InnerText.Trim();

            return el;
        }

    }
}
