using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers
{
    using Models;
    using Data;
    using RtfWebApp.Models;

    [ApiController]
    public class SkilController : ApiBaseController<Skill>
    {
        
        public SkilController(ApplicationDbContext context):
            base(context)
        {
        }
         
    }
}