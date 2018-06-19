using System;

namespace CloudAcademy.CA151.Lab.Ging.Biz
{
    public class SponsoredLink : Link
    {
        public string SponsorName { get; set; }
        public decimal CostPerImpersion { get; set; }

        public SponsoredLink(string linkType, string descriptionText, string uRL, string sponsorName, decimal costPerImpersion, int impresions) : base(linkType, descriptionText, uRL, impresions)
        {
            SponsorName = sponsorName;
            CostPerImpersion = costPerImpersion;
        }
    }
}
