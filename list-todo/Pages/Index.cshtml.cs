using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoContext _context;

        public IndexModel(TodoContext context)
        {
            _context = context;
        }

        public IList<TodoItem> Tasks { get; set; }

        [BindProperty]
        public TodoItem NewTask { get; set; }

        public async Task OnGetAsync()
        {
            Tasks = await _context.TodoItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.TodoItems.Add(NewTask);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
