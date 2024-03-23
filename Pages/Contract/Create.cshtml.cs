using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RoomRentalManagementSolution.Pages.Contract
{
    public class CreateModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public CreateModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string customerName { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
            customerName = customer == null ? string.Empty : customer.Name;
            /*ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Name");*/
        ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomName");
            return Page();
        }

        [BindProperty]
        public RoomRentalManagementSolution.Models.Contract Contract { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contracts == null || Contract == null)
            {
                return Page();
            }

            _context.Contracts.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
