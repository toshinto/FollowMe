using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Vote : BaseModel<int>
    {
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
