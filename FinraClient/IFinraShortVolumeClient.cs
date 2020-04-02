using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinraClient
{
    public interface IFinraShortVolumeClient
    {
        Task<List<FinraRecord>> GetShortVolume(DateTime date);
    }
}