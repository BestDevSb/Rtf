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

    [Route("api/[controller]")]
    [ApiController]
    public class SkilController : ApiBaseController<Skil>
    {
        
        public SkilController(ApplicationDbContext context):
            base(context)
        {
        }
         
    }
}