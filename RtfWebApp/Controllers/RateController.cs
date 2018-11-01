using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Controllers
{
    using Models;
    using Data;
    using RtfWebApp.Models;

    public class RateController:ApiBaseController<Rating>
    {
        public RateController(ApplicationDbContext context):base(context)
        { }
    }
}
