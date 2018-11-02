using Microsoft.AspNetCore.Mvc;
using RtfWebApp.Data;
using RtfWebApp.Models;

namespace RtfWebApp.Controllers.Api
{
    [ApiController]
    public class AuthorRatingController : ApiBaseController<AuthorRating>
    {
        public AuthorRatingController(ApplicationDbContext context) : base(context)
        {
        }
    }
}