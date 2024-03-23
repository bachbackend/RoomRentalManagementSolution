using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace RoomRentalManagementSolution.Pages.Contract
{
    public class DetailsModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public DetailsModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

      public RoomRentalManagementSolution.Models.Contract Contract { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FirstOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }
            else 
            {
                Contract = contract;
            }
            return Page();
        }
    }
}
