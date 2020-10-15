using System;
using System.Collections.Generic;
using VisitorService.Models;

namespace VisitorService.Data
{
    public class MockVisitorRepository : IVisitorRepository
    {
        public void CreateVisitor(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public void DeleteVisitor(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public Visitor GetVisitor(int id)
        {
            return new Visitor { Id = 0, FirstName = "Joe", LastName = "Bloggs", CompanyName = "Joe's Pizza", EmailAddress = "joe@bloggs.com", PhoneNumber = "07911222333", VehicleRegistration = "ABC1 DE2", AccessibilityRequirements = "Wheelchair user." };

        }

        public Visitor GetVisitorByEmail(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Visitor> GetVisitors()
        {
            var visitors = new List<Visitor>
            {
                new Visitor { Id = 0, FirstName = "Joe", LastName = "Bloggs", CompanyName = "Joe's Pizza", EmailAddress = "joe@bloggs.com", PhoneNumber = "07911222333", VehicleRegistration = "ABC1 DE2", AccessibilityRequirements = "Wheelchair user." },
                new Visitor { Id = 1, FirstName = "Barry", LastName = "Hebbron", CompanyName = "Teesside University", EmailAddress = "b.d.hebbron@tees.ac.uk", PhoneNumber = "07911234567", VehicleRegistration = "BDH 5", AccessibilityRequirements = "" },
                new Visitor { Id = 2, FirstName = "Zafar", LastName = "Khan", CompanyName = "Teesside University", EmailAddress = "z.khan@tees.ac.uk", PhoneNumber = "079117654321", VehicleRegistration = "DE3 5FR", AccessibilityRequirements = "" }
            };
            return visitors;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateVisitor(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        //public VisitorImage GetVisitorImage(int Id)
        //{
        //    return new VisitorImage { Id = 0, ImagePath = @"\\server\ems\images\70d4d503-346c-4506-9e86-fadc5a7ed5a9.png" };
        //}

        //public IEnumerable<VisitorImage> GetVisitorImages()
        //{
        //    var visitorImages = new List<VisitorImage>
        //    {
        //        new VisitorImage { Id = 0, ImagePath = @"\\server\ems\images\70d4d503-346c-4506-9e86-fadc5a7ed5a9.png" },
        //        new VisitorImage { Id = 1, ImagePath = @"\\server\ems\images\9d0b08c1-a791-4a9f-9d0d-a0dde7175e5e.png" },
        //        new VisitorImage { Id = 2, ImagePath = @"\\server\ems\images\28600aa2-b483-4576-a1d0-d50a1e217698.png" }
        //    };
        //    return visitorImages;
        //}
    }
}
