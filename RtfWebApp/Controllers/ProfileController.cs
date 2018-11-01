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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ApiBaseController<Profile>
    {
        
        public ProfileController(ApplicationDbContext context):
            base(context)
        {
        }
         
    }
}