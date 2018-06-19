using System;

namespace CloudAcademy.CA151.Lab.Ging.Biz
{
    public class NonSponsoredLink : Link
    {
        public DateTime DateLastCrawled { get; set; }
        public string LinkContentType{ get; set; }

        public NonSponsoredLink(string linkType, string descriptionText, string uRL, DateTime dateLastCrawled, string linkContentType, int impresions) : base(linkType, descriptionText, uRL, impresions)
        {
            DateLastCrawled = dateLastCrawled;
            LinkContentType = linkContentType;
        }
    }
}
