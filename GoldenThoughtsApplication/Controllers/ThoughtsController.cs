using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldenThoughtsApplication.Data;
using GoldenThoughtsApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoldenThoughtsApplication.Controllers
{
    public class ThoughtsController : Controller
    {
        private readonly GoldenThoughtsApplicationContext _context;

        public ThoughtsController(GoldenThoughtsApplicationContext context)
        {
            _context = context;
        }

        // GET: Thoughts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thought.ToListAsync());
        }

        // GET: Thoughts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thought = await _context.Thought
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thought == null)
            {
                return NotFound();
            }

            return View(thought);
        }

        // GET: Thoughts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thoughts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Date,AuthorName")] Thought thought)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thought);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thought);
        }

        // GET: Thoughts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thought = await _context.Thought.FindAsync(id);
            if (thought == null)
            {
                return NotFound();
            }
            return View(thought);
        }

        // POST: Thoughts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Date,AuthorName")] Thought thought)
        {
            if (id != thought.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thought);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoughtExists(thought.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(thought);
        }

        // GET: Thoughts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thought = await _context.Thought
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thought == null)
            {
                return NotFound();
            }

            return View(thought);
        }

        // POST: Thoughts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thought = await _context.Thought.FindAsync(id);
            if (thought != null)
            {
                _context.Thought.Remove(thought);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoughtExists(int id)
        {
            return _context.Thought.Any(e => e.Id == id);
        }
    }
}
