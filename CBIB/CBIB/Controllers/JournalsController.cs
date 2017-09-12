using CBIB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CBIB.Controllers
{
    public class JournalsController : Controller
    {
        private readonly CBIBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JournalsController(CBIBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Journals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Journal.ToListAsync());
        }

        // GET: Journals/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .SingleOrDefaultAsync(m => m.ID == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // GET: Journals/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Year")] Journal journal)
        {
            var user = await _userManager.GetUserAsync(User);
            var author = _context.Author.Find(user.AuthorID);

            if (ModelState.IsValid)
            {
                journal.AuthorID = user.AuthorID;
                _context.Add(journal);
                await _context.SaveChangesAsync();

                author.Journals.Add(journal);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.SingleOrDefaultAsync(m => m.ID == id);
            if (journal == null)
            {
                return NotFound();
            }
            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Title,Year,AuthorID")] Journal journal)
        {
            if (id != journal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .SingleOrDefaultAsync(m => m.ID == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var journal = await _context.Journal.SingleOrDefaultAsync(m => m.ID == id);
            _context.Journal.Remove(journal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JournalExists(long id)
        {
            return _context.Journal.Any(e => e.ID == id);
        }
    }
}
