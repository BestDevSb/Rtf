using RtfWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<RecomendedEmployees>> GetRecommendedEmployeesAsync(int employeeId);
    }
}
