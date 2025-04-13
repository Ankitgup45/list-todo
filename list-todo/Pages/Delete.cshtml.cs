using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TodoContext _context;

        public DeleteModel(TodoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TodoItem = await _context.TodoItems.FindAsync(id);
            if (TodoItem == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var task = await _context.TodoItems.FindAsync(id);
            if (task != null)
            {
                _context.TodoItems.Remove(task);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
