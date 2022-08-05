using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinraClient
{
    public interface IFinraShortVolumeClient<T>
    {
        Task<List<T>> GetShortVolume(DateTime date);
    }
}