﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomRentalManagementSolution.Models;

namespace RoomRentalManagementSolution.Pages.RoomAttribute.price
{
    public class PriceCreateModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public PriceCreateModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomPrice RoomPrice { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RoomPrices == null || RoomPrice == null)
            {
                return Page();
            }

            _context.RoomPrices.Add(RoomPrice);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thêm giá phòng thành công!";
            return Page();
        }
    }
}
