using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomRentalManagementSolution.Models;

namespace RoomRentalManagementSolution.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly RoomRentalManagementSolution.Models.RoomRetalManagementContext _context;

        public IndexModel(RoomRentalManagementSolution.Models.RoomRetalManagementContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string username, string name, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                TempData["ErrorMessage"] = "Không được để trống";
                return Page();
            }

            if (!confirmPassword.Equals(password))
            {
                TempData["ErrorMessage"] = "Mật khẩu nhập lại không trùng với mật khẩu hiện tại";
                return Page();
            }
            

            Account temp = _context.Accounts.FirstOrDefault(x => x.Username == username);
            if (temp != null)
            {
                TempData["ErrorMessage"] = "Tài khoản đã tồn tại";
                return Page();
            }
            Account account = new Account();
            account.Username = username;
            account.Password = password;
            account.Name = name;
            account.Role = "staff";
            account.Status = true;
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Login/Index"); 

        }
    }
}
