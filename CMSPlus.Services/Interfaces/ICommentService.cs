using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentEntity> GetById(int id); 
        Task<IEnumerable<CommentEntity>> GetByTopicId(int topicId); 
        Task Create(CommentEntity entity); 
        Task Update(CommentEntity entity); 
        Task Delete(int id); 
    }
}
