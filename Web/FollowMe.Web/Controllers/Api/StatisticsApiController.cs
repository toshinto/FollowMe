using FollowMe.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FollowMe.Web.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public StatisticsApiController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<string> Test()
        {
            var userId = this.data
                .Users
                //.Where(x => x.Id.Length < 3)
                .Select(t => t.Id)
                .ToArray();

            return userId;
        }
    }
}
