using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace IOUTracker.Models
{
    public class IOUCreateModel
    {

        [Required]
        public string Lender { get; set; }
        [Required]
        public string Borrower { get; set; }
        [Required]
        public double Amount { get; set; }

        public IOU CreateIOU()
        {
            var iou = new IOU()
            {
                Id = Guid.NewGuid(),
                LenderId = Lender,
                BorrowerId = Borrower,
                Amount = Amount,
                DateCreatedUTC = DateTime.UtcNow
            };
            return iou;
        }
    }
}
