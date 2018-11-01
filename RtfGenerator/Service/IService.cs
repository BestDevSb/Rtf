using RtfWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RtfGenerator.Service
{
    internal interface IService
    {
        Task GenerateAsync();
        Task GenerateHRRatingsAsync();
    }
}
