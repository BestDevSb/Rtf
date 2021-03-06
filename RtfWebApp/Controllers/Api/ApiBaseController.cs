﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Controllers.Api
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

        [HttpGet("api/[controller]/{Id}")]
        public virtual TEntity Get(int Id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet("api/[controller]/")]
        public virtual IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        [HttpPost("api/[controller]/")]
        public virtual TEntity Add(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        [HttpPost("api/[controller]/range")]
        public virtual async Task<IEnumerable<TEntity>> AddRange([FromBody]IEnumerable<TEntity> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }

            return entities;
        }

        [HttpPut("api/[controller]/")]
        public virtual TEntity Update(TEntity entity)
        {
            _context.Add(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        [HttpDelete("api/[controller]/clean")]
        public async Task<IActionResult> Clean()
        {
            _context.RemoveRange(_context.Set<TEntity>().ToList());
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
