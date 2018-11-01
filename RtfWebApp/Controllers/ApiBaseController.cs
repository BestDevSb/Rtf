using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Controllers
{
    using Data;
    using Models;
    using RtfWebApp.Models;

    public abstract class ApiBaseController<TEntity>: ControllerBase where TEntity : class, IHaveId
    {
        protected ApplicationDbContext _context;
        public ApiBaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public TEntity Get(int Id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        [HttpPost]
        public virtual TEntity Add(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        [HttpPost("range")]
        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        [HttpPut]
        public TEntity Update(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }
    }
}
