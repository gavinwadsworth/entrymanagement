using System;
using System.Collections.Generic;
using System.Linq;
using VisitorService.Models;

namespace VisitorService.Data
{
    public class SqlVisitorRepository : IVisitorRepository
    {
        private readonly VisitorContext _context;
        public SqlVisitorRepository(VisitorContext context)
        {
            _context = context;
        }

        public void CreateVisitor(Visitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }
            _context.Visitors.Add(visitor);
        }

        public void DeleteVisitor(Visitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }
            _context.Visitors.Remove(visitor);
        }

        public Visitor GetVisitor(int id)
        {
            return _context.Visitors.FirstOrDefault(v => v.Id == id);
        }

        public Visitor GetVisitorByEmail(string emailAddress)
        {
            return _context.Visitors.FirstOrDefault(v => v.EmailAddress == emailAddress);
        }

        public IEnumerable<Visitor> GetVisitors()
        {
            return _context.Visitors.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0) ;
        }

        public void UpdateVisitor(Visitor visitor)
        {
            // Not required.
        }
    }
}
