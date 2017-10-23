using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using BibliotecaMVC.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public AutoresController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        // GET: Autors
        public async Task<IActionResult> Index(string filtroPesquisa, string ordenacao)
        {
            ViewBag.NomeSortParm = String.IsNullOrEmpty(ordenacao) ? "titulo_desc" : "";

            ViewBag.filtroPesquisa = filtroPesquisa;

            var autores = from l in _context.Autor
                         select l;

            if (!String.IsNullOrEmpty(filtroPesquisa))
            {
                autores = autores.Where(s => s.Nome.ToUpper().Contains(filtroPesquisa.ToUpper()));
            }

            switch (ordenacao)
            {
                case "titulo_desc":
                    autores = autores.OrderByDescending(s => s.Nome);
                    break;
                default:
                    autores = autores.OrderBy(s => s.Nome);
                    break;
            }

            return View(await autores.ToListAsync());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var autor = await _context.Autor;

            var autor = await _context.Autor.SingleOrDefaultAsync(a => a.AutorID == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View(new Autor());
        }

        // POST: Autors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutorID,Nome")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.SingleOrDefaultAsync(m => m.AutorID == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutorID,Nome")] Autor autor)
        {
            if (id != autor.AutorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.AutorID))
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
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.SingleOrDefaultAsync(m => m.AutorID == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.Autor.SingleOrDefaultAsync(m => m.AutorID == id);
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AutorExists(int id)
        {
            return _context.Autor.Any(e => e.AutorID == id);
        }
    }
}
