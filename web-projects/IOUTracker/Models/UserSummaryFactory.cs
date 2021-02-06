using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class UserSummaryFactory
    {
        IOUDbContext context;

        public UserSummaryFactory(IOUDbContext context)
        {
            this.context = context;
        }

        public async Task<UserSummaryModel> BuildSummaryForAsync(string name)
        {
            await Task.CompletedTask;
            var borrowers = context.IOUs.Where(x => x.LenderId.ToLower() == name.ToLower()).ToList();
            var lenders = context.IOUs.Where(x => x.BorrowerId.ToLower() == name.ToLower()).ToList();

            var model = new UserSummaryModel(name, lenders, borrowers);

            return model;
        }
    }
}
