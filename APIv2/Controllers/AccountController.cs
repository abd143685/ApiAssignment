using APIv2.Data;
using APIv2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIv2.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountsContext _context;

        public AccountController(AccountsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccounts()
        {
            if(_context.account == null)
            {
                return NotFound();
            }
            return await _context.account.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accounts>> GetAccount(int id)
        {
            var acc = await _context.account.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            return acc;
        }

        [HttpPost]
        public async Task<ActionResult<Accounts>> PostAccount(Accounts account)
        {
            _context.account.Add(account);
            await _context.SaveChangesAsync();

            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> PutAccount(int id, Accounts account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(account).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }

            return NoContent();
        }

        private bool AccountAvailable(int id)
        {
            return _context.account?.Any(x => x.Id == id) ?? false;
        }
    }
}
