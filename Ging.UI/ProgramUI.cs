using System;
using System.Security.Cryptography.X509Certificates;
using CloudAcademy.CA151.Lab.Ging.Biz;

namespace CloudAcademy.CA151.Lab.Ging.UI
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        public SearchEngine SearchEngine;

        public ProgramUI(IConsole consoleForAllReadsAndWrites)
        {
            _console = consoleForAllReadsAndWrites;
            SearchEngine = new SearchEngine();
        }

        public void Run()
        {
            bool finished = false;
            //SearchEngine.PreLoadLists();
            do
            { 
                _console.Write("Command (addlink, listlinks, search, or financials): ");
                var command = _console.ReadLine().ToLower();

                if (String.IsNullOrWhiteSpace(command))
                {
                    finished = true;
                }
                else if (command == "addlink")
                {
                    AddLink();
                }
                else if (command == "listlinks")
                {
                    ListLinks();
                }
                else if (command == "search")
                {
                    Search();
                }
                else if (command == "financials")
                {
                    Financials();
                }

                //SearchEngine.PrintTheList();

                //!Leave this at the bottom for spacing reasons!
                _console.WriteLine();
            } while (!finished);
        }

        public void AddLink()
        {
            _console.Write("Link Type (sponsoredlink, nonsponsoredlink): ");
            var linkType = _console.ReadLine().ToLower();

            _console.Write("Please enter a description of your site. This will appear when your site is searched: ");
            var descriptionText = _console.ReadLine();

            _console.Write("Please enter your site URL: ");
            var uRl = _console.ReadLine();


            if (linkType == "sponsoredlink")
            {
                _console.Write("Please enter the sponsor name: ");
                var sponsorName = _console.ReadLine();

                _console.Write("Please enter the decimal cost per impression (i.e. search hit): ");
                var costPerImpersion = Decimal.Parse(_console.ReadLine());

                SearchEngine.AddItemToLinkList(linkType, descriptionText, uRl, sponsorName, costPerImpersion);
            }
            else if (linkType == "nonsponsoredlink")
            {
                _console.Write("Please enter the date when your site was last crawled: ");
                var dateLastCrawled = DateTime.Parse(_console.ReadLine());

                _console.Write("Please enter the link content type (forum, blog, other): ");
                var linkContentType = _console.ReadLine().ToLower();

                SearchEngine.AddItemToLinkList(linkType, descriptionText, uRl, dateLastCrawled, linkContentType);
            }

            _console.WriteLine($"You've successfully added a {linkType}");

        }

        public void ListLinks()
        {
            _console.WriteLine();
           _console.WriteLine("Sponsored Links: ");
            var sponsoredLinks = SearchEngine.SponsoredLinksListCopy();
            foreach (var link in sponsoredLinks)
            {
                _console.WriteLine($"URL: {link.URL}, Description: {link.DescriptionText}, Impression Count: {link.Impresions}");
            }

            _console.WriteLine();
            _console.WriteLine("NonSponsored Links: ");
            var nonsponsoredLinks = SearchEngine.NonSponsoredLinksListCopy();
            foreach (var link in nonsponsoredLinks)
            {
                _console.WriteLine($"URL: {link.URL}, Description: {link.DescriptionText}, Impression Count: {link.Impresions}");
            }
        }

        public string SearchQuery;
        public void Search()
        {
            _console.WriteLine("What are you looking for?");
            SetSearchQuery(ref SearchQuery);

            var sponsSearchResults = SearchEngine.SearchLinksSponsoredLinks(SearchQuery);
            _console.WriteLine();
            _console.WriteLine("Sponsored Links: ");
            foreach (var searchResult in sponsSearchResults)
            {
                _console.WriteLine($"Url: {searchResult.URL}");
                _console.WriteLine($"Description: {searchResult.DescriptionText}");

            }

            var nonSponsSearchResults = SearchEngine.SearchLinksNonSponsoredLinks(SearchQuery);
            _console.WriteLine();
            _console.WriteLine("NonSponsored Links: ");
            foreach (var searchResult in nonSponsSearchResults)
            {
                _console.WriteLine($"Url: {searchResult.URL}");
                _console.WriteLine($"Description: {searchResult.DescriptionText}");
                _console.WriteLine($"Date last crawled: {searchResult.DateLastCrawled}");
            }
        }

        void SetSearchQuery(ref string search)
        {
            SearchQuery = _console.ReadLine();
        }

        public void Financials()
        {
            throw new NotImplementedException();
        }
    }
}
