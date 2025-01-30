﻿using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Repositories
{
    public class CommentRepository : Repository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommentEntity>> GetByTopicId(int topicId)
        {
            var comments = await _dbSet
               .Where(c => c.TopicId == topicId)
               .ToListAsync();
            return comments;
        }
    }
}
