using System;

namespace CloudAcademy.CA151.Lab.Ging.Biz
{
    public class Link
    {

        public string LinkType { get; set; }
        public string DescriptionText { get; set; }
        public string URL { get; set; }
        public int Impresions { get; set; }

        public Link(string linkType, string descriptionText, string uRL, int impresions)
        {
            LinkType = linkType;
            DescriptionText = descriptionText;
            URL = uRL;
            Impresions = impresions;
        }
    }
}
