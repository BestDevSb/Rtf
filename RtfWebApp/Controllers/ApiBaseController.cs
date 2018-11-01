using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Controllers
{
    using Data;
    using Models;

    public abstract class ApiBaseController<TEntity>: ControllerBase where TEntity : class, IHaveId
    {
        protected ApplicationDbContext _context;
        public ApiBaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/[controller]/{id}")]
        public TEntity Get(int Id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet("api/[controller]/")]
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        [HttpPost("api/[controller]/")]
        public TEntity Add(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        [HttpPut("api/[controller]/")]
        public TEntity Update(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }
    }
}
