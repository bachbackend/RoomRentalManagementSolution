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
    public class DetailsModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public DetailsModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

      public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
