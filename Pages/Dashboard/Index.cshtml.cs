using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomRentalManagementSolution.Models;

namespace RoomRentalManagementSolution.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public IndexModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            string userName = HttpContext.Session.GetString("username");
            string role = HttpContext.Session.GetString("role");
            if (userName == null || role == null)
            {
                return RedirectToPage("/Login/Index");
            }
            if (role.Equals("staff"))
            {
                return RedirectToPage("/Room/Index");
            }
            if (_context.Accounts != null)
            { 
                
                Account = await _context.Accounts.Where(x => x.Role.Equals("staff")).ToListAsync();
            }
            return Page();
        }


    }
}
