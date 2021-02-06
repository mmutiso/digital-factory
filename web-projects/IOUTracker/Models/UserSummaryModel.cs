using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class UserSummaryModel
    {

        public UserSummaryModel(string name, List<IOU> lenders, List<IOU> borrowers)
        {
            Name = name;
            Owes = lenders.Select(x => new IOUModel() { Name = x.Lender.Name, Amount = x.Amount }).ToList();
            OwedBy = borrowers.Select(x => new IOUModel() { Name = x.Borrower.Name, Amount = x.Amount }).ToList();
        }

        public string Name { get; set; }
        public List<IOUModel> Owes { get; set; }
        public List<IOUModel> OwedBy { get; set; }
        public decimal Balance => OwedBy.Select(x => x.Amount).Sum() - Owes.Select(x => x.Amount).Sum();
    }
}
