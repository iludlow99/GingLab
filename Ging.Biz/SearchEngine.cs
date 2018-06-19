using System;
using System.Collections.Generic;

namespace CloudAcademy.CA151.Lab.Ging.Biz
{
    public class SearchEngine
    {
        private List<SponsoredLink> _sponsoredLinks = new List<SponsoredLink>();
        private List<NonSponsoredLink> _nonSponsoredLinks = new List<NonSponsoredLink>();

        public void PreLoadLists()
        {
            _sponsoredLinks.Add(new SponsoredLink("sponsoredlink", "This is a computer website by Nike", "https://www.computersbynike.com", "Nike", (decimal)0.05, 0));

            _nonSponsoredLinks.Add(new NonSponsoredLink("nonsponsoredlink", "This is a socks webpage by Samsung", "https://socksbysamsung.com", new DateTime(6/15/18), "blog", 0));
        }


        //*** Add link to list ***
        public void AddItemToLinkList(string linkType, string descriptionText, string uRL, string sponsorName, decimal costPerImpersion)
        {
            _sponsoredLinks.Add(new SponsoredLink(linkType, descriptionText, uRL, sponsorName, costPerImpersion, 0));
        }

        public void AddItemToLinkList(string linkType, string uRL, string descriptionText, DateTime dateLastCrawled, string linkContentType)
        {
            _nonSponsoredLinks.Add(new NonSponsoredLink(linkType, uRL, descriptionText, dateLastCrawled, linkContentType, 0));
        }
        //*** Add link to list ***


        //*** Get all list links ***
        public List<SponsoredLink> SponsoredLinksListCopy()
        {
            var newList = new List<SponsoredLink>();
            foreach (var link in _sponsoredLinks)
            {
                newList.Add(link);
            }

            return newList;
        }

        public List<NonSponsoredLink> NonSponsoredLinksListCopy()
        {
            var newList = new List<NonSponsoredLink>();
            foreach (var link in _nonSponsoredLinks)
            {
                newList.Add(link);
            }

            return newList;
        }
        //*** Get all list links ***


        public List<SponsoredLink> SearchLinksSponsoredLinks(string searchQuery)
        {
            var searchQueryResults = new List<SponsoredLink>();

            foreach (var sponsoredLink in _sponsoredLinks)
            {
                if(sponsoredLink.DescriptionText.ToLower().Contains(searchQuery.ToLower()))
                {
                    searchQueryResults.Add(sponsoredLink);
                    sponsoredLink.Impresions++;
                }
            }
            
            return searchQueryResults;
        }

        public List<NonSponsoredLink> SearchLinksNonSponsoredLinks(string searchQuery)
        {
            var searchQueryResults = new List<NonSponsoredLink>();

            foreach (var nonSponsoredLink in _nonSponsoredLinks)
            {
                if (nonSponsoredLink.DescriptionText.ToLower().Contains(searchQuery.ToLower()))
                {
                    searchQueryResults.Add(nonSponsoredLink);
                    nonSponsoredLink.Impresions++;
                }
            }

            return searchQueryResults;
        }
    }
}
