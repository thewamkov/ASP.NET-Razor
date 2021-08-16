using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public  IEnumerable<Book> Books { get; set; }


        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
