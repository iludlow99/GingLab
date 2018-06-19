using System;
using System.Diagnostics.CodeAnalysis;
using CloudAcademy.CA151.Lab.Ging.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudAcademy.CA151.Lab.Ging.UnitTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProgramUITest
    {
        //vvv Probably done wrong vvv
        [TestMethod]
        public void ProgramUIAddLinkWhenSomethingShouldSomething()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
            {
                "sponsoredlink", "Some description for the fist test site", "https://www.idek.com", "Nike", "0.03",
                "nonsponsoredlink", "Other description for my nonsponsoredlink site", "https://www.whatamievendoing.com", "6/15/18", "blog"
            });
            var programUI = new ProgramUI(mockConsole);

            //Act
            programUI.Run();

            //Assert
            var searchEngine = programUI.SearchEngine;

            mockConsole.Write("Link Type (sponsoredlink, nonsponsoredlink): ");
            var linkType = mockConsole.ReadLine().ToLower();

            mockConsole.Write("Please enter a description of your site. This will appear when your site is searched: ");
            var descriptionText = mockConsole.ReadLine();

            mockConsole.Write("Please enter your site URL: ");
            var uRl = mockConsole.ReadLine();


            if (linkType == "sponsoredlink")
            {
                mockConsole.Write("Please enter the sponsor name: ");
                var sponsorName = mockConsole.ReadLine();

                mockConsole.Write("Please enter the decimal cost per impression (i.e. search hit): ");
                var costPerImpersion = Decimal.Parse(mockConsole.ReadLine());

                searchEngine.AddItemToLinkList(linkType, descriptionText, uRl, sponsorName, costPerImpersion);
            }
            else if (linkType == "nonsponsoredlink")
            {
                mockConsole.Write("Please enter the date when your site was last crawled: ");
                var dateLastCrawled = DateTime.Parse(mockConsole.ReadLine());

                mockConsole.Write("Please enter the link content type (forum, blog, other): ");
                var linkContentType = mockConsole.ReadLine().ToLower();

                searchEngine.AddItemToLinkList(linkType, descriptionText, uRl, dateLastCrawled, linkContentType);
            }

            mockConsole.WriteLine($"You've successfully added a {linkType}");

            var sponsList = searchEngine.SponsoredLinksListCopy();
            foreach (var spons in sponsList)
            {
                return spons;
            }
            
            
            var outputText = mockConsole.Output;
            Assert.AreEqual("sponsoredlink", );
        }

        [TestMethod]
        public void ProgramUIListLinksWhenSomethingShouldSomething()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[] { "listlinks", "something", "something" });
            var programUI = new ProgramUI(mockConsole);

            //Act
            programUI.Run();

            //Assert
            var searchEngine = programUI.SearchEngine;
            var outputText = mockConsole.Output;
            throw new NotImplementedException("Verify any expectations");
        }

        [TestMethod]
        public void ProgramUISearchWhenSomethingShouldSomething()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[] { "search", "something", "something" });
            var programUI = new ProgramUI(mockConsole);

            //Act
            programUI.Run();

            //Assert
            var searchEngine = programUI.SearchEngine;
            var outputText = mockConsole.Output;
            throw new NotImplementedException("Verify any expectations");
        }

        [TestMethod]
        public void ProgramUIFinancialsWhenSomethingShouldSomething()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[] { "financials" });
            var programUI = new ProgramUI(mockConsole);

            //Act
            programUI.Run();

            //Assert
            var searchEngine = programUI.SearchEngine;
            var outputText = mockConsole.Output;
            throw new NotImplementedException("Verify any expectations");
        }

        // TODO: Add any tests as needed to reach full coverage
    }
}
