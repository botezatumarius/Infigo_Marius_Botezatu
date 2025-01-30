using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Models.CommentModels
{
    public class CommentCreateModel : BaseCommentModel
    {
        public string FullName { get; set; }
        public string Body { get; set; }
        public int TopicId { get; set; }
        public string? TopicSystemName { get; set; }
    }
}
