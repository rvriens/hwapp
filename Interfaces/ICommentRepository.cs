using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> ListAll();
        void Add(Comment person);
    }
}