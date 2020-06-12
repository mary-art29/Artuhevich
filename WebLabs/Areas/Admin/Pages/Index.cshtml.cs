using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs
{
    public class IndexModel : PageModel
    {
        private readonly WebLabs.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebLabs.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
