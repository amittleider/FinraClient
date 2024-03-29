﻿using FluentAssertions;
using System;
using System.IO;
using Xunit;

namespace FinraClient.Tests
{
    public class FinraRecordResponseParserTests
    {
        [Fact]
        public void Should_ParseSampleResponse()
        {
            using (StreamReader reader = new StreamReader("finra_response.txt"))
            {
                string responseString = reader.ReadToEnd();

                FinraRecordResponseParser parser = new FinraRecordResponseParser();
                var finraRecords = parser.ParseResponse(responseString);

                finraRecords[0].Date.Should().Be(new DateTime(2018, 11, 5));
                finraRecords[0].Market.Should().Be("Q,N");
                finraRecords[0].ShortExemptVolume.Should().Be(0);
                finraRecords[0].ShortVolume.Should().Be(80887);
                finraRecords[0].Symbol.Should().Be("A");
                finraRecords[0].TotalVolume.Should().Be(371966);
            }
        }
    }
}
