using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class UserSummaryFactory
    {
        ITrackerRepository repository;

        public UserSummaryFactory(ITrackerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserSummaryModel> BuildSummaryFor(string name)
        {
            var borrowers = await repository.GetMyBorrowersAsync(name);
            var lenders = await repository.GetMyLendersAsync(name);

            var model = new UserSummaryModel(name, lenders, borrowers);

            return model;
        }
    }
}
