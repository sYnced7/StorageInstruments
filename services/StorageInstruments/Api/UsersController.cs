using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageInstruments.DataContract.Service;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.DTO;


namespace StorageInstruments.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ISeriLog logger;

        public UsersController(IUserService userService, ISeriLog logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpPost("{username}/{password}")]
        public async Task<ActionResult<UserDto>> GetUser(string username, string password)
        {
            var user = await userService.Login(username, password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //// GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
        {
            var aux = await userService.Register(user.UserName, user.Password);

            if (aux == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
