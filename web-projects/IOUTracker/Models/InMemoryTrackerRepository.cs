using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public class InMemoryTrackerRepository : ITrackerRepository
    {
        IOUDbContext context;
        public InMemoryTrackerRepository(IOUDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddUserAsync(User user)
        {
            await context.AddAsync<User>(user);
            await context.SaveChangesAsync();
        }

        public async  Task CreateIOUAsync(IOU iou)
        {
            await context.AddAsync(iou);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string name)
        {
            var user = context.Users.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (user != null)
            {
                user.Delete();
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<IOU>> GetMyBorrowersAsync(string name)
        {
            await Task.CompletedTask;
            return context.IOUs.Where(x => x.Lender.Name.ToLower() == name.ToLower()).ToList();
        }

        public async Task<List<IOU>> GetMyLendersAsync(string name)
        {
            await Task.CompletedTask;
            return context.IOUs.Where(x => x.Borrower.Name.ToLower() == name.ToLower()).ToList();
        }


        public async Task<User> GetUserAsync(string Name)
        {
            await Task.CompletedTask;
            return context.Users.Where(x => !x.Deleted).Where(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Task.CompletedTask;
            return context.Users.Where(x => !x.Deleted).ToList();
        }

        public bool UserExists(string name)
        {
            return context.Users.Any(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
