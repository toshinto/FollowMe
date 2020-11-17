using System.Threading.Tasks;

using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        // POST /api/votes
        // Request body: {"postId":1,"isUpVote":true}
        // Response body: {"votesCount":16}
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(input.PostId, userId, input.IsUpVote);
            var votes = this.votesService.GetVotes(input.PostId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
