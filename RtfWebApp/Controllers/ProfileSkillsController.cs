using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RtfWebApp.Data;
using RtfWebApp.Models;

namespace RtfWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileSkillsController : ApiBaseController<ProfileSkills>
    {
        public ProfileSkillsController(ApplicationDbContext context) : base(context)
        {
        }
    }
}