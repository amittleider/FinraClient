using System.Collections.Generic;

namespace FinraClient
{
    public interface IFinraResponseParser<T>
    {
        List<T> ParseResponse(string finraResponse);
    }
}