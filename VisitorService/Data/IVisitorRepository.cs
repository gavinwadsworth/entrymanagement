using System.Collections.Generic;
using VisitorService.Models;

namespace VisitorService.Data
{
    public interface IVisitorRepository
    {
        bool SaveChanges();
        IEnumerable<Visitor> GetVisitors();
        Visitor GetVisitor(int id);
        Visitor GetVisitorByEmail(string emailAddress);
        void CreateVisitor(Visitor visitor);
        void UpdateVisitor(Visitor visitor);
        void DeleteVisitor(Visitor visitor);
    }

    //public interface IVisitorImageRepository
    //{
    //    IEnumerable<VisitorImage> GetVisitorImages();
    //    VisitorImage GetVisitorImage(int id);
    //}
}
