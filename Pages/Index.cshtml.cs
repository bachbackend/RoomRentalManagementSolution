using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoomRentalManagementSolution.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        
            public IActionResult OnGet()
            {
                return new RedirectToPageResult("/Login/Index"); // Replace with your desired path
            }
        

    }
}