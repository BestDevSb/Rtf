using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RtfWebApp.Data;
using RtfWebApp.Models;

namespace RtfWebApp.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<RecomendedEmployees>> GetRecommendedEmployeesAsync(int employeeId)
        {
            return await _dbContext.RecomendedEmployees
                                    .Where(x => x.EmployeeId == employeeId)
                                    .OrderByDescending(x => x.IntersectCount)
                                    .ThenByDescending(x => x.TotalRate)
                                    .ThenByDescending(x => x.TotalWeight)
                                    .Take(10)
                                    .ToListAsync();
        }
    }
}
