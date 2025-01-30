using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories;

public class TopicRepository:Repository<TopicEntity>,ITopicRepository
{
    public TopicRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<TopicEntity?> GetBySystemName(string systemName)
    {
        var result = await _dbSet.SingleOrDefaultAsync(topic => topic.SystemName == systemName);
        return result;
    }

    public async Task<TopicEntity?> GetTopicWithComments(int topicId)
    {
        return await _dbSet
            .Include(t => t.Comments) 
            .SingleOrDefaultAsync(topic => topic.Id == topicId);
    }
}