using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace RoomRentalManagementSolution.Pages.Contract
{
    public class IndexModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public IndexModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

        public IList<RoomRentalManagementSolution.Models.Contract> Contract { get;set; } = default!;

        [BindProperty]
        public int customerId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            customerId = id;
            if (_context.Contracts != null)
            {
                Contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.Room).Where(x => x.CustomerId == id).ToListAsync();
            }
            return Page();
        }
    }
}
