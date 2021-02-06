using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Models
{
    public interface ITrackerRepository
    {
        bool UserExists(string name);
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(string Name);
        Task<List<User>> GetUsersAsync();
        Task CreateIOUAsync(IOU iou);
        Task<List<IOU>> GetMyBorrowersAsync(string name);
        Task<List<IOU>> GetMyLendersAsync(string name);
        Task DeleteUserAsync(string name);
    }
}
