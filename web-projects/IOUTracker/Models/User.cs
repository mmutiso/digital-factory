using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string name)
        {
            Name = name;
            DateCreatedUTC = DateTime.UtcNow;
            Deleted = false;
        }

        public void Delete()
        {
            DateDeletedUTC = DateTime.UtcNow;
            Deleted = true;
        }

        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreatedUTC { get; set; }
        public DateTime? DateDeletedUTC { get; set; }

        public ICollection<IOU> LenderIOUs { get; set; }
        public ICollection<IOU> BorrowerIOUs { get; set; }
    }
}
