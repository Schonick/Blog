using SportClub.Models;
using SportClub.Models.Blog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SportClub.BlogRepository
{
    public class PostRepository : IRepository<Post>
    {
        private ModelContext db;
        public PostRepository()
        {
            db = new ModelContext();
        }
        public IEnumerable<Post> GetList()
        {
            return db.Posts;
        }

        public Post GetOneObject(int id)
        {
            return db.Posts.Find(id);
        }

        public void Create(Post item)
        {
         
            db.Posts.Add(item);
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }

        public void Save()
        {
          
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}