using SportClub.Models;
using SportClub.Models.Blog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SportClub.BlogRepository
{
    public class MethodForBlog : IRepository<Category>
    {
        private ModelContext db;

        public MethodForBlog()
        {
            db = new ModelContext();
        }

        public IEnumerable<Category> GetList()
        {
            return db.Categorys;
        }

        public Category GetOneObject(int id)
        {
            return db.Categorys.Find(id);

        }

        public void Create(Category item)
        {
            db.Categorys.Add(item);

        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category != null)
                db.Categorys.Remove(category);

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