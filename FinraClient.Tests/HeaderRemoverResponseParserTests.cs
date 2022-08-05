using FluentAssertions;
using System.IO;
using Xunit;

namespace FinraClient.Tests
{
    public class HeaderRemoverResponseParserTests
    {
        [Fact]
        public void Should_ParseSampleResponse()
        {
            using (StreamReader reader = new StreamReader("finra_response.txt"))
            {
                string responseString = reader.ReadToEnd();

                HeaderFooterRemoverResponseParser parser = new HeaderFooterRemoverResponseParser();
                var finraRecords = parser.ParseResponse(responseString);

                finraRecords[0].Should().Be("20181105|A|80887|0|371966|Q,N");
                finraRecords[7758].Should().Be("20181105|ZYNE|40171|0|76293|Q,N");
            }
        }
    }
}
