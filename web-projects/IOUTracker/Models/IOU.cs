using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class IOU
    {
        public Guid Id { get; set; }
        public string LenderId { get; set; }
        public string BorrowerId { get; set; }
        public User Borrower { get; set; }
        public User Lender { get; set; }
        public double Amount { get; set; }
        public DateTime DateCreatedUTC { get; set; }
    }
}
