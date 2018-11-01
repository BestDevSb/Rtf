using Microsoft.AspNetCore.Mvc;
using RtfWebApp.Controllers.Api;
using RtfWebApp.Data;
using RtfWebApp.Models;

namespace RtfWebApp.Controllers
{
    [ApiController]
    public class SolutionsSkillsController : ApiBaseController<SolutionSkils>
    {
        public SolutionsSkillsController(ApplicationDbContext context) : base(context)
        {
        }
    }
}