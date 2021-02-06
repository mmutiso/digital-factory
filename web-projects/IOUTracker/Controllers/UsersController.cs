using IOUTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IOUTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        ITrackerRepository repository;
        ILogger<UsersController> logger;
        UserSummaryFactory userSummaryFactory;

        public UsersController(ITrackerRepository repository, ILogger<UsersController> logger, UserSummaryFactory userSummaryFactory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(repository));
            this.userSummaryFactory = userSummaryFactory ?? throw new ArgumentNullException(nameof(userSummaryFactory));
        }

       [HttpGet]
        public async Task<ActionResult<object>> Index()
        {
            var users = await repository.GetUsersAsync();

            if (users.Count == 0)
            {
                return new { users = new string[] { } };
            }

            var response = users.Select(x => x.Name).OrderBy(x => x).ToList();
            return new { users = response };
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (repository.UserExists(userModel.Name))
            {
                var user = await repository.GetUserAsync(userModel.Name);

                return user;
            }
            else
            {
                var user = new User(userModel.Name);
                await repository.AddUserAsync(user);

                return user;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSummaryModel>> GetUser(string id)
        {
            var exists = repository.UserExists(id);
            if (!exists)
            {
                return NotFound();
            }
            await Task.CompletedTask;
            var userSummary = await userSummaryFactory.BuildSummaryForAsync(id);

            return userSummary;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var exists = repository.UserExists(id);
            if (!exists)
            {
                return NotFound();
            }

            await repository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
