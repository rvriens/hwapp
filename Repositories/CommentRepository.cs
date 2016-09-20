using System;
using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class CommentRepository : Interfaces.ICommentRepository
    {
        
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Comment comment)
        {
            this._dbContext.Comments.Add(comment);
            this._dbContext.SaveChanges();
        }

        public IEnumerable<Comment> ListAll()
        {
            return this._dbContext.Comments;
        }
    }
}