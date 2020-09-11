using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;

namespace Web.GraphQL
{
    public class Query
    {
        private readonly UberfliegerContext _context;

        public Query(UberfliegerContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProduct(string identifier)
        {
            return _context.Products.Where(p => p.Identifier == identifier);

        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public IQueryable<Module> GetModule(string identifier)
        {
            return _context.Modules.Where(m => m.Identifier == identifier);
        }

        public IQueryable<Lesson> GetLesson(string moduleIdentifier, int lessonNo)
        {
            return _context.Lessons
                .Include(l => l.Module)
                .Where(l => l.Module.Identifier == moduleIdentifier && l.LessonNo == lessonNo);
        }
    }
}
