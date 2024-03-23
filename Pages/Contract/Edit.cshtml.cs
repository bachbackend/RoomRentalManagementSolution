using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace RoomRentalManagementSolution.Pages.Contract
{
    public class EditModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public EditModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomRentalManagementSolution.Models.Contract Contract { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract =  await _context.Contracts.FirstOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }
            Contract = contract;
           ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
           ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(Contract.ContractId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContractExists(int id)
        {
          return (_context.Contracts?.Any(e => e.ContractId == id)).GetValueOrDefault();
        }
    }
}
