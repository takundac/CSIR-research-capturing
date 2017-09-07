using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CBIB.Models;

namespace CBIB.Controllers
{
    public class ResearchInfoController : Controller
    {
        private readonly CBIBContext _context;

        public ResearchInfoController(CBIBContext context)
        {
            _context = context;    
        }

        // GET: ResearchInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResearchInfo.ToListAsync());
        }

        // GET: ResearchInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researchInfo = await _context.ResearchInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (researchInfo == null)
            {
                return NotFound();
            }

            return View(researchInfo);
        }

        // GET: ResearchInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResearchInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Year,Type,Author,Genre,AdditionalInfo,Node")] ResearchInfo researchInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(researchInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(researchInfo);
        }

        // GET: ResearchInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researchInfo = await _context.ResearchInfo.SingleOrDefaultAsync(m => m.ID == id);
            if (researchInfo == null)
            {
                return NotFound();
            }
            return View(researchInfo);
        }

        // POST: ResearchInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Year,Type,Author,Genre,AdditionalInfo,Node")] ResearchInfo researchInfo)
        {
            if (id != researchInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(researchInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchInfoExists(researchInfo.ID))
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
            return View(researchInfo);
        }

        // GET: ResearchInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researchInfo = await _context.ResearchInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (researchInfo == null)
            {
                return NotFound();
            }

            return View(researchInfo);
        }

        // POST: ResearchInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var researchInfo = await _context.ResearchInfo.SingleOrDefaultAsync(m => m.ID == id);
            _context.ResearchInfo.Remove(researchInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResearchInfoExists(int id)
        {
            return _context.ResearchInfo.Any(e => e.ID == id);
        }
    }
}
