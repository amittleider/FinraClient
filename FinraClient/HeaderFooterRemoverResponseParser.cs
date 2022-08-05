using System.Collections.Generic;
using System.Linq;

namespace FinraClient
{
    public class HeaderFooterRemoverResponseParser : IFinraResponseParser<string>
    {
        public List<string> ParseResponse(string finraResponse)
        {
            var split = finraResponse.Split("\r\n");
            return split.Skip(1).TakeWhile(line => line.Contains("|")).ToList();
        }
    }
}
