using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] 
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            //Create
            if (id == null)
                return Page();


            Book = await _db.Book.FirstOrDefaultAsync(obj => obj.ID == id);

            //Update
            if (Book == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.ID == 0)
                    _db.Book.Add(Book);
                else
                    _db.Book.Update(Book);

                //var BoolFromDb = await _db.Book.FindAsync(Book.ID);
                //BoolFromDb.Name = Book.Name;
                //BoolFromDb.ISBN = Book.ISBN;
                //BoolFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}